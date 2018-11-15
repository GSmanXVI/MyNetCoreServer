using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer.Services
{
    public class TestService : ITestService
    {
        public string Test()
        {
            return "Hello from TestService";
        }
    }
}
