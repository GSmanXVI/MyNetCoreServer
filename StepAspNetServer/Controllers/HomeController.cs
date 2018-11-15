using StepAspNetServer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer.Controllers
{
    public class HomeController : Controller
    {
        public ITestService TestService { get; }

        public HomeController(ITestService testService)
        {
            TestService = testService;
        }

        // Home/Index
        public string Index()
        {
            return $"<h1>Index</h1><p>{TestService.Test()}</p>";
        }

        // Home/About?name=Gleb&age=24
        public string About(string name, int age)
        {
            return $"<h1>About {name} {age}</h1>";
        }
    }
}
