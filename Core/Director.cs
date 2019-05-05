using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core
{
    public class Director
    {
        public Director()
        {

        }

        public Dictionary<string, IEnumerable<string>> _dict = new Dictionary<string, IEnumerable<string>>()
        {
            {"user1", new []{"London", "Paris", "Dubai"} },
            {"user2", new []{"NewYork", "Vienna", "Dubai"} },
            {"user3", new []{"Berlin", "Amsterdam", "Dubai"} }
        };



        public async Task<HttpResponseMessage> ExecuteWithRetry(string url)
        {
            HttpResponseMessage result = null;
            bool success = false;
            do
            {
                using (var client = new HttpClient())
                {
                    result = client.GetAsync(url).Result;
                    success = result.IsSuccessStatusCode;
                }
            }
            while (!success);
            return result;
        }

        public async Task<Weather> GetWeatherFor(string city)
        { 
           var result = await ExecuteWithRetry($"http://localhost:56789/api/weather/city/{city}");
           var resultString = result.Content.ReadAsStringAsync();
           var rawWeather = JsonConvert.DeserializeObject<Weather>(resultString.Result);

           return rawWeather;
        }


    }
}
