using StepAspNetServer.Infrastructure;
using StepAspNetServer.Middlewares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer
{
    class StartupConfigurator : IConfigurator
    {
        public void Configure(MiddlewareBuilder builder)
        {
            builder
                .Use<LoggerMiddleware>()
                //.Use<IndexMiddleware>()
                .Use<StaticFilesMiddleware>();
        }
    }
}
