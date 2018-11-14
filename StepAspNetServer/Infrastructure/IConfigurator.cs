using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer.Infrastructure
{
    public interface IConfigurator
    {
        void Configure(MiddlewareBuilder builder);
        void ConfigureServices(IocBuilder builder);
    }
}
