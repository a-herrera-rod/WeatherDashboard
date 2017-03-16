using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherDashboard.Webapi;
using WeatherDashboard.Webapi.Controllers;
using WeatherDashboard.Webapi.Models;
using WeatherDashboard.Core.Interfaces.Repository;
using WeatherDashboard.Core.Interfaces.Service;
using WeatherDashboard.Infrastructure.Repository;
using WeatherDashboard.Infrastructure.Services;
using WeatherDashboard.Core.Model;
using WeatherDashboard.Infrastructure.DependencyInjection;

namespace WeatherDashboard.Webapi.Tests.Controllers
{
    /// <summary>
    /// Summary description for ForecastControllerTest
    /// </summary>
    [TestClass]
    public class ForecastControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var MockService = new Moq.Mock<IWeatherDashboardService>();
            var Response = new Mock<EForecast>();
            Random oRandom = new Random();
            string sProviderId = oRandom.Next(1, 2).ToString();
            string sCityId = oRandom.Next(1, 5).ToString();
            MockService.Setup(s => s.GetForecast(sProviderId, sCityId)).Returns(Response.Object);

            WeatherDashboardImplementationRepository repository = new WeatherDashboardImplementationRepository();

            // Act
            EForecast result = repository.GetForecast(sProviderId, sCityId);

            // Assert
            Assert.IsNotNull(result);            
            Assert.IsInstanceOfType(result, typeof(EForecast));
            Assert.IsNotNull(((EForecast)result).DailyForecast);
            Assert.AreEqual(7, ((EForecast)result).DailyForecast.Count);
        }
    }
}
