using Microsoft.AspNetCore.Hosting;
using System;
using Wrapper;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*5000")
                .UseStartup<Startup>()
                .Build();

            host.Run();


            Console.WriteLine("Hello World!");
        }
    }
}
