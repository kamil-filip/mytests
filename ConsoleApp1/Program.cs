using System;
using Wrapper.Lib;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var t = new WeatherService();

            var output = t.GetWeather("London");

            Console.WriteLine("Hello World!");
        }
    }
}
