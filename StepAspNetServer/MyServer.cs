using StepAspNetServer.Infrastructure;
using StepAspNetServer.Middlewares;
using StepAspNetServer.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StepAspNetServer
{
    class MyServer
    {
        public string Domain { get; set; }
        public int Port { get; set; }

        private HttpListener httpListener;
        private HttpHandler middleware;

        public MyServer(string domain, int port)
        {
            Domain = domain;
            Port = port;
            httpListener = new HttpListener();
            httpListener.Prefixes.Add($"{domain}:{port}/");
        }

        public void Configure<T>() where T : IConfigurator, new()
        {
            var config = new T();
            var builder = new MiddlewareBuilder();
            config.Configure(builder);
            middleware = builder.Build();
        }

        public void Run()
        {
            httpListener.Start();
            while (true)
            {
                var context = httpListener.GetContext();
                Task.Run(() => Process(context));
            }
        }

        private void Process(HttpListenerContext context)
        {
            middleware?.Invoke(context);
        }
    }
}
