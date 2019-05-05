
using Core;
using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            var myDir = new Director();
            var output = myDir.GetWeatherFor("London");



            Console.WriteLine("Hello World!");
        }
    }
}
