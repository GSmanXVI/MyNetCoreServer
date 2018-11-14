using System;

namespace StepAspNetServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var domain = "http://localhost";
            var port = 8080;

            var server = new MyServer(domain, port);
            Console.WriteLine($"Server started (port: {port})");
            server.Configure<StartupConfigurator>();
            server.Run();
        }
    }
}
