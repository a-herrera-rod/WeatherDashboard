using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Model;

namespace WeatherDashboard.Core.Interfaces.Repository
{
    public interface IWeatherDashboardRepository
    {
        List<EProvider> GetProviders();
        List<ECity> GetCities();
        EForecast GetForecast(string providerId, string cityId);
    }
}
