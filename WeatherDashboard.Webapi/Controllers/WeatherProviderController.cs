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
    public class WeatherProviderController : ApiController
    {
        private readonly IWeatherDashboardService weatherDashboardService;
        private bool validateRequests = true;

        public WeatherProviderController(IWeatherDashboardService _weatherDashboardService)
        {
            weatherDashboardService = _weatherDashboardService;
        }

        public void disableValidation()
        {
            validateRequests = false;
        }

        [ResponseType(typeof(ResponseModel))]
        public ResponseModel Get()
        {
            try
            {               
                if (validateRequests)
                {
                    RequestHandler.Validate(ModelState, Request.Headers.Authorization, false);
                }

                List<EProvider> lstProviders = weatherDashboardService.GetProviders();                    
                List<ProviderModel> lstResult = new List<ProviderModel>();
                for (int i = 0; i < lstProviders.Count(); i++)
                {
                    lstResult.Add(new ProviderModel { Id = lstProviders[i].Id, Name = lstProviders[i].Name });
                }
                return new SuccessResponseList<ProviderModel>(lstResult);
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
