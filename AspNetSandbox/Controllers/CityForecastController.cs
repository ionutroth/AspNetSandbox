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
    public class CityForecastController : ControllerBase
    {
        public CityForecastController()
        {
        }

        [HttpGet]
        public CityForcast Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?lat=52.52&lon=13.4&appid=7ad9707743286cc164f725a3cd3d3c6e");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseToWeatherForecast(response.Content);

            var context = ConvertResponseToWeatherForecast(response.Content);
            Console.WriteLine(context);
        }

        [NonAction]
        public CityForcast ConvertResponseToWeatherForecast(string content)
        {
            var json = JObject.Parse(content);

            return new CityForcast {

                Long = json["coord"].Value<float>("lon"),
                Lat = json["coord"].Value<float>("lat"),
                City = json.Value<string>("name")

            };
        }

        public static explicit operator CityForecastController(CityForcast v)
        {
            throw new NotImplementedException();
        }
    }
}
