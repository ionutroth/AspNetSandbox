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
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private const float KELVIN_CONST = 273.15f;


        public WeatherForecastController()
        {
            
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=11&lon=11&exclude=hourly,minutely&appid=7ad9707743286cc164f725a3cd3d3c6e");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseToWeatherForecast(response.Content);

            var context = ConvertResponseToWeatherForecast(response.Content);
            Console.WriteLine(context);
        }
        [NonAction]
        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
        {
            var json = JObject.Parse(content);
            
            return Enumerable.Range(1, days).Select(index => {
                var jsonDailyForecast = json["daily"][index];
                var unixDateTime = jsonDailyForecast.Value<long>("dt");
                var weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");

                return new WeatherForecast {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(jsonDailyForecast),
                    Summary = weatherSummary
                };
            }).ToArray();
        }
        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyForecast)
        {
            return (int)Math.Round(jsonDailyForecast["temp"].Value<float>("day") - KELVIN_CONST);
        }

        //http://api.openweathermap.org/data/2.5/forecast/daily?lat=44.4268&lon=26.1025&cnt=1&appid=7ad9707743286cc164f725a3cd3d3c6e
    }
}
