using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wrapper.Models;

namespace Wrapper.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        [HttpGet("[action]/{city}")]
        public async  Task<IActionResult> City(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                  //  //http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=6a408defff9733fa7085ddd06871b02b&units=metric
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync(
                        $"/data/2.5/weather?q={city},uk&APPID=6a408defff9733fa7085ddd06871b02b&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);

                    return Ok(new
                    {
                        Temp = rawWeather.Main.Temp,
                        Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                        City = rawWeather.Name
                    });
                }
                catch(HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }

            }
        }
    }
}