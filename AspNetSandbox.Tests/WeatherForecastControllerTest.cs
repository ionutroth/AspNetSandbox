// <copyright file="WeatherForecastControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Tests
{
    using System;
    using System.IO;
    using ApiSandbox;
    using ApiSandbox.Controllers;
    using Xunit;

    /// <summary>
    /// Test suite for WeatherControllerForecast.
    /// </summary>
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Clear", weatherForecastForTomorrow.Summary);
            Assert.Equal(18, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 3), weatherForecastForTomorrow.Date);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastForTommorowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastAfterTomorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Clear", weatherForecastAfterTomorrow.Summary);
            Assert.Equal(20, weatherForecastAfterTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 4), weatherForecastAfterTomorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.OpenWeatherApi.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using var tr = new StreamReader(resourceStream);
            return tr.ReadToEnd();
        }
    }
}
