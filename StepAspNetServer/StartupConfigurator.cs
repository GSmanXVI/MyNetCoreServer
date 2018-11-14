using StepAspNetServer.Infrastructure;
using StepAspNetServer.Middlewares;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer
{
    //localhost:8080/Home/Index
    //localhost:8080/Home/Index?name=Gleb

    class StartupConfigurator : IConfigurator
    {
        public void Configure(MiddlewareBuilder builder)
        {
            builder
                .Use<LoggerMiddleware>()
                //.Use<IndexMiddleware>()
                .Use<StaticFilesMiddleware>()
                .Use<MvcMiddleware>();
        }

        public void ConfigureServices(IocBuilder builder)
        {

        }
    }
}
