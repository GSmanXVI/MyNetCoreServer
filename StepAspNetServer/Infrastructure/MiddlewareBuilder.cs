using StepAspNetServer.Middlewares;
using StepAspNetServer.Tools;
using System;
using System.Collections.Generic;

namespace StepAspNetServer.Infrastructure
{
    public class MiddlewareBuilder
    {
        private Stack<Type> types = new Stack<Type>();

        public MiddlewareBuilder Use<T>() where T : IMiddleware
        {
            types.Push(typeof(T));
            return this;
        }

        public HttpHandler Build()
        {
            HttpHandler handler = context => context.Response.Close();

            while (types.Count > 0)
            {
                Type type = types.Pop();
                var middleware = Activator.CreateInstance(type, handler) as IMiddleware;
                handler = middleware.RunTask;
            }

            return handler;
        }
    }
}
