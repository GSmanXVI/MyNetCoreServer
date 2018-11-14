using StepAspNetServer.Tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StepAspNetServer.Middlewares
{
    class LoggerMiddleware : IMiddleware
    {
        private HttpHandler next;

        public LoggerMiddleware(HttpHandler next)
        {
            this.next = next;
        }

        public void RunTask(HttpListenerContext context)
        {
            var request = context.Request;
            var date = DateTime.Now;
            next?.Invoke(context);
            Console.WriteLine($"{request.HttpMethod} - {request.RawUrl}");
        }
    }
}
