using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherDashboard.Webapi;
using WeatherDashboard.Webapi.Controllers;
using WeatherDashboard.Webapi.Models;
using WeatherDashboard.Core.Interfaces.Service;
using WeatherDashboard.Core.Model;

namespace WeatherDashboard.Webapi.Tests.Controllers
{
    [TestClass]
    public class WeatherProviderControllerTest
    {
        [TestMethod]
        public void GetFailedResponse()
        {
            // Arrange
            var mockService = new Mock<IWeatherDashboardService>();
            var response = new List<EProvider>();

            mockService.Setup(s => s.GetProviders()).Returns(response);            
                        
            WeatherProviderController controller = new WeatherProviderController(mockService.Object);

            // Act
            ResponseModel result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.success);            
            Assert.IsInstanceOfType(result, typeof(FailureResponse));            
        }

        [TestMethod]
        public void GetSuccessResponse()
        {
            // Arrange
            var mockService = new Moq.Mock<IWeatherDashboardService>();
            var response = new List<EProvider>();
            response.Add(new EProvider { Id = "1" });
            response.Add(new EProvider { Id = "2" });

            mockService.Setup(s => s.GetProviders()).Returns(response);

            WeatherProviderController controller = new WeatherProviderController(mockService.Object);
            controller.disableValidation();

            // Act
            ResponseModel result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.success);
            Assert.IsInstanceOfType(result, typeof(SuccessResponseList<ProviderModel>));
            Assert.AreEqual(2, ((SuccessResponseList<ProviderModel>)result).total_elements);
        }
    }
}
