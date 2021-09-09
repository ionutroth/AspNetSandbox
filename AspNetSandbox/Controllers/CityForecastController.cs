// <copyright file="CityForecastController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiSandbox.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    /// <summary>
    /// This controller allows us to see the weather in a certain latitude longitude combination.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CityForecastController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityForecastController"/> class.
        /// </summary>
        public CityForecastController()
        {
        }

        /// <summary>Performs an explicit conversion from <see cref="CityForcast" /> to <see cref="CityForecastController" />.</summary>
        /// <param name="v">The v.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator CityForecastController(CityForcast v)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the weather from inputed longitude and latitude.</summary>
        /// <returns>cityForecast object.</returns>
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

        /// <summary>Converts the response to weather cityForecast object.</summary>
        /// <param name="content">The content.</param>
        /// <returns>CityForecast object.</returns>
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
