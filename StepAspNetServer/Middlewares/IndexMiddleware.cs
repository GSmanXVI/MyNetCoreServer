using StepAspNetServer.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StepAspNetServer.Middlewares
{
    class IndexMiddleware : IMiddleware
    {
        private HttpHandler next;

        public IndexMiddleware(HttpHandler next)
        {
            this.next = next;
        }

        public void RunTask(HttpListenerContext context)
        {
            var html = File.ReadAllText("./wwwroot/index.html");
            context.Response.ContentType = "text/html";
            using (var writer = new StreamWriter(context.Response.OutputStream))
            {
                writer.Write(html);
            }

            next?.Invoke(context);
        }
    }
}
