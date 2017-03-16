using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Model;
using WeatherDashboard.Core.Interfaces.Repository;
using WeatherDashboard.Core.Interfaces.Service;


namespace WeatherDashboard.Infrastructure.Services
{
    public class WeatherDashboardImplementationService : IWeatherDashboardService
    {
        private readonly IWeatherDashboardRepository _weatherDashboardRepository;

        public WeatherDashboardImplementationService(IWeatherDashboardRepository weatherDashboardRepository)
        {
            _weatherDashboardRepository = weatherDashboardRepository;
        }

        public List<EProvider> GetProviders()
        {
            return _weatherDashboardRepository.GetProviders();
        }

        public List<ECity> GetCities()
        {
            return _weatherDashboardRepository.GetCities();
        }

        public EForecast GetForecast(string providerId, string cityId)
        {
            return _weatherDashboardRepository.GetForecast(providerId, cityId);
        }

    }
}
