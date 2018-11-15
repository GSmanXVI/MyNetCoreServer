using StepAspNetServer.Controllers;
using StepAspNetServer.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace StepAspNetServer.Middlewares
{
    class MvcMiddleware : IMiddleware
    {
        private HttpHandler next;

        public MvcMiddleware(HttpHandler next)
        {
            this.next = next;
        }

        // /Home/Index -> RawUrl
        public void RunTask(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var parts = request.RawUrl.Split('/');
            var controllerName = parts[1] + "Controller";
            var actionName = parts[2].Split('?')[0];

            var controllerType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower().Contains(controllerName.ToLower()));

            if (controllerType == null)
            {
                Error(context);
                return;
            }

            var actionType = controllerType.GetMethods()
                .FirstOrDefault(x => x.Name.ToLower() == actionName.ToLower());

            if (actionType == null)
            {
                Error(context);
                return;
            }

            var methodParams = actionType.GetParameters();
            var queryParams = request.QueryString;
            var arrParams = new object[methodParams.Length];
            for (int i = 0; i < arrParams.Length; i++)
            {
                arrParams[i] = queryParams[methodParams[i].Name];
                arrParams[i] = Convert.ChangeType(arrParams[i], methodParams[i].ParameterType);
                Console.WriteLine(arrParams[i]);
            }

            //var controller = Activator.CreateInstance(controllerType);
            var controller = MyServer.Services.Resolve(controllerType);
            var result = actionType.Invoke(controller, arrParams);

            response.ContentType = "text/html";
            response.StatusCode = 200;
            using (var writer = new StreamWriter(response.OutputStream))
            {
                writer.Write(result);
            }

            next?.Invoke(context);
        }

        private void Error(HttpListenerContext context)
        {
            context.Response.StatusCode = 404;
            Console.WriteLine(context.Request);
            context.Response.Close();
        }
    }
}
