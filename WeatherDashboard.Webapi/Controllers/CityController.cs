using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherDashboard.Webapi.Models;
using WeatherDashboard.Webapi.Handlers;
using WeatherDashboard.Core.Model;
using WeatherDashboard.Core.Interfaces.Service;

namespace WeatherDashboard.Webapi.Controllers
{
    public class CityController : ApiController
    {
        private readonly IWeatherDashboardService weatherDashboardService;

        public CityController(IWeatherDashboardService _weatherDashboardService)
        {
            weatherDashboardService = _weatherDashboardService;
        }

        [ResponseType(typeof(ResponseModel))]
        public ResponseModel Get()
        {
            try
            {
                RequestHandler.Validate(ModelState, Request.Headers.Authorization, false);

                List<ECity> lstCities = weatherDashboardService.GetCities();
                List<CityModel> lstResult = new List<CityModel>();
                for (int i = 0; i < lstCities.Count(); i++)
                {
                    lstResult.Add(new CityModel { Id = lstCities[i].Id, Name = lstCities[i].Name });
                }
                return new SuccessResponseList<CityModel>(lstResult);
            }
            catch (HttpException ex)
            {
                return new FailureResponse(ex.GetHttpCode(), ex.Message);
            }
            catch (Exception ex)
            {
                return new FailureResponse(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
