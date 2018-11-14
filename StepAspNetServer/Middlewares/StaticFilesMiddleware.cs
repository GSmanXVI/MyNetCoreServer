using StepAspNetServer.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StepAspNetServer.Middlewares
{
    class StaticFilesMiddleware : IMiddleware
    {
        private HttpHandler next;

        public StaticFilesMiddleware(HttpHandler next)
        {
            this.next = next;
        }

        public void RunTask(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            if (Path.HasExtension(request.RawUrl))
            {
                var file = request.RawUrl.TrimStart('/');
                var dir = Directory.GetCurrentDirectory();
                var path = $@"{dir}\..\..\..\wwwroot\{file}";
                if (File.Exists(path))
                {
                    var bytes = File.ReadAllBytes(path);
                    using (var writer = new BinaryWriter(response.OutputStream))
                    {
                        writer.Write(bytes);
                    }
                    return;
                }
            }
            next?.Invoke(context);
        }
    }
}
