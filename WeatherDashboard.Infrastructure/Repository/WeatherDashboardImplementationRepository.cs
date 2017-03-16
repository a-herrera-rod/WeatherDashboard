using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Model;
using WeatherDashboard.Core.Interfaces.Repository;
using WeatherDashboard.Infrastructure.Data;
using WeatherDashboard.Infrastructure.Translator;
using WeatherDashboard.Infrastructure.Providers;


namespace WeatherDashboard.Infrastructure.Repository
{
    public class WeatherDashboardImplementationRepository: IWeatherDashboardRepository
    {
        private WeatherDashboardData db;

        public WeatherDashboardImplementationRepository()
        {
            db = WeatherDashboardData.Instance;
        }

        public List<EProvider> GetProviders()
        {
            return db.GetProviderList();
        }

        public List<ECity> GetCities()
        {
            return db.GetCityList();
        }

        public EForecast GetForecast(string sProviderId, string sCityId)
        {
            string url = GetRequestUrl(sProviderId, sCityId);
            HttpProvider http = new HttpProvider(url);
            string sResult = http.GetResponse();

            return ForecastProviderFactory.ConvertToForecastData(sProviderId, sResult);
        }

        private string GetRequestUrl(string sProviderId, string sCityId)
        {
            string sUrl = "";
            EProvider oProvider = db.GetProvider(sProviderId);
            ECity oCity = db.GetCity(sCityId);
            if (oProvider != null && oCity != null)
            {
                sUrl = ForecastProviderFactory.BuildRequestUrl(oProvider, oCity);
            }
            return sUrl;
        }
    }
}
