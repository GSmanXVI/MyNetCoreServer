using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StepAspNetServer.Middlewares
{
    public interface IMiddleware
    {
        void RunTask(HttpListenerContext context);
    }
}
