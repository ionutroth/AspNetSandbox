using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApiSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private const float KELVIN_CONST = 273.15f;

        public CityController()
        {

        }

        [HttpGet]
        public CityForcast Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?lat=10&lon=34&appid=7ad9707743286cc164f725a3cd3d3c6e");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseToWeatherForecast(response.Content);

            var context = ConvertResponseToWeatherForecast(response.Content);
            Console.WriteLine(context);
        }

        public CityForcast ConvertResponseToWeatherForecast(string content)
        {
            var json = JObject.Parse(content);

            return new CityForcast {

                Long = json["coord"].Value<float>("lon"),
                Lat = json["coord"].Value<float>("lat")

            };
        }
    }

    //public class ityController : ControllerBase
    //{
        
    //    public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
    //    {
    //        var json = JObject.Parse(content);

    //        return Enumerable.Range(1, days).Select(index =>
    //        {
    //            var jsonDailyForecast = json["daily"][index];
    //            var unixDateTime = jsonDailyForecast.Value<long>("dt");
    //            var weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");

    //            return new WeatherForecast {

    //            };
    //        }).ToArray();
    //    }
    //}
}
