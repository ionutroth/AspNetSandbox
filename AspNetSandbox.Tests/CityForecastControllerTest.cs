using ApiSandbox.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class CityControllerTest
    {

        [Fact]
        public void ConvertResponseToInfoTest()
        {
            // Assume
            // tring content = '{"coord":{"lon":13.4113,"lat":52.5234},"weather":[{"id":800,"main":"Clear","description":"clear sky","icon":"01n"}],"base":"stations","main":{"temp":286.69,"feels_like":286.48,"temp_min":284.16,"temp_max":288.68,"pressure":1014,"humidity":91},"visibility":10000,"wind":{"speed":1.34,"deg":242,"gust":1.34},"clouds":{"all":0},"dt":1630626062,"sys":{"type":2,"id":2011538,"country":"DE","sunrise":1630642849,"sunset":1630691461},"timezone":7200,"id":2950159,"name":"Berlin","cod":200}';
            var controller = new CityController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTomorrow = ((CityController)output)[0];
            Assert.Equal(52.5244, (weatherForecastForTomorrow.Summary));
            Assert.Equal(13.4105, (weatherForecastForTomorrow.TemperatureC));
            Assert.Equal(new DateTime(2021, 9, 3), (weatherForecastForTomorrow.Date));

        }
    }
}
