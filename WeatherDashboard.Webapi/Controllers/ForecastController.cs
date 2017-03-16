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
    public class ForecastController : ApiController
    {
        private readonly IWeatherDashboardService weatherDashboardService;

        public ForecastController(IWeatherDashboardService _weatherDashboardService)
        {
            weatherDashboardService = _weatherDashboardService;
        }

        [ResponseType(typeof(ResponseModel))]
        public ResponseModel Get(string sProviderId, string sCityId)
        {
            try
            {
                //RequestHandler.Validate(ModelState, Request.Headers.Authorization, false);
                
                EForecast oForecastResult = weatherDashboardService.GetForecast(sProviderId, sCityId);
                return new SuccessResponse<EForecast>(oForecastResult);
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
