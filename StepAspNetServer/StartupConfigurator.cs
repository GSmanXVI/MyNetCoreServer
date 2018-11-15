using StepAspNetServer.Controllers;
using StepAspNetServer.Infrastructure;
using StepAspNetServer.Middlewares;
using StepAspNetServer.Services;
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
                .Use<StaticFilesMiddleware>()
                .Use<MvcMiddleware>();
        }

        public void ConfigureServices(IocBuilder builder)
        {   
            builder.Register<TestServiceTwo>().As<ITestService>();
        }
    }
}
