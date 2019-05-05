using Microsoft.AspNetCore.Hosting;
using System;
using Wrapper;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:56789")
                .UseStartup<Startup>()
                .Build();

                host.Run();

            Console.WriteLine("Hello World!");





        }
    }
}
