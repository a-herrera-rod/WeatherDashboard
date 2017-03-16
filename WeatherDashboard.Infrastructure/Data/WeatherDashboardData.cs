using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Model;

namespace WeatherDashboard.Infrastructure.Data
{
    public class WeatherDashboardData
    {
        private List<EProvider> lstProviders;
        private List<ECity> lstCities;
        private static WeatherDashboardData instance;

        private WeatherDashboardData()
        {
            lstProviders = new List<EProvider>();
            lstProviders.Add(new EProvider { Id = "1", Name = "Forecast.io", Url = "https://api.darksky.net/forecast/{0}/{1},{2}", Key = "060eff3d4ad59f58ff2e0783a860f1bf" });
            lstProviders.Add(new EProvider { Id = "2", Name = "WeatherUnderground", Url = "http://api.wunderground.com/api/{0}/forecast10day/q/{1}/{2}.json", Key = "dea7050aa41dcac4" });

            lstCities = new List<ECity>();
            lstCities.Add(new ECity { Id = "1", Name = "Lima", Country = "Peru", Latitude= "-12.00000000", Longitude = "-77.12000275" });
            lstCities.Add(new ECity { Id = "2", Name = "Mendoza", Country = "Argentina", Latitude = "-32.83000183", Longitude = "-68.77999878" });
            lstCities.Add(new ECity { Id = "3", Name = "Miami", Country = "FL", Latitude = "25.78000069", Longitude = "-80.19999695" });
            lstCities.Add(new ECity { Id = "4", Name = "Tokyo", Country = "Japan", Latitude = "35.68000031", Longitude = "139.77000427" });
            lstCities.Add(new ECity { Id = "5", Name = "Madrid", Country = "Spain", Latitude = "40.45000076", Longitude = "-3.54999995" });
        }

        public List<EProvider> GetProviderList()
        {
            return lstProviders;
        }

        public List<ECity> GetCityList()
        {
            return lstCities;
        }

        public EProvider GetProvider(string Id)
        {
            return lstProviders.Find(p => p.Id.Equals(Id));
        }

        public ECity GetCity(string Id)
        {
            return lstCities.Find(c => c.Id.Equals(Id));
        }

        public static WeatherDashboardData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherDashboardData();
                }
                return instance;
            }
        }
    }
}
