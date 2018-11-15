using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer.Services
{
    public class TestServiceTwo : ITestService
    {
        public string Test()
        {
            return "Hello from TestServiceTwo";
        }
    }
}
