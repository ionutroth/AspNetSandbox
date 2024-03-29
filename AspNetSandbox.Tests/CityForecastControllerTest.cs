﻿// <copyright file="CityForecastControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Tests
{
    using System;
    using ApiSandbox;
    using ApiSandbox.Controllers;
    using Xunit;

    /// <summary>
    /// Test suite for CityForecastController.
    /// </summary>
    public class CityForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToInfoTest()
        {
            // Assume
            var content = "{\"coord\":{\"lon\":13.4113,\"lat\":52.5234},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"base\":\"stations\",\"main\":{\"temp\":286.69,\"feels_like\":286.48,\"temp_min\":284.16,\"temp_max\":288.68,\"pressure\":1014,\"humidity\":91},\"visibility\":10000,\"wind\":{\"speed\":1.34,\"deg\":242,\"gust\":1.34},\"clouds\":{\"all\":0},\"dt\":1630626062,\"sys\":{\"type\":2,\"id\":2011538,\"country\":\"DE\",\"sunrise\":1630642849,\"sunset\":1630691461},\"timezone\":7200,\"id\":2950159,\"name\":\"Berlin\",\"cod\":200}";
            var controller = new CityForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var cityWeatherForecast = (CityForcast)output;
            Assert.Equal(53, Math.Round(cityWeatherForecast.Lat));
            Assert.Equal(13, Math.Round(cityWeatherForecast.Long));
            Assert.Equal("Berlin", cityWeatherForecast.City);
        }
    }
}
