using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wrapper.Controllers;

namespace Wrapper.Lib
{
    public class WeatherService
    {

        public async Task<object> GetWeather(string cityName)
        {
            var test = new WeatherController();
            var output = await test.City(cityName);


            return null;
            
        }

    }
}
