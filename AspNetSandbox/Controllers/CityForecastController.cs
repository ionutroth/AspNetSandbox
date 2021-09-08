using System;
using Microsoft.AspNetCore.Mvc;
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

        public static explicit operator CityForecastController(CityForcast v)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public CityForcast Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?lat=52.52&lon=13.4&appid=97368af7fb3676da33fa82cf4053348f");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseToWeatherForecast(response.Content);
        }

        [NonAction]
        public CityForcast ConvertResponseToWeatherForecast(string content)
        {
            var json = JObject.Parse(content);

            return new CityForcast
            {
                Long = json["coord"].Value<float>("lon"),
                Lat = json["coord"].Value<float>("lat"),
                City = json.Value<string>("name"),
            };
        }
    }
}
