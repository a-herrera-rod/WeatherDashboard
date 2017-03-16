using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Model;

namespace WeatherDashboard.Infrastructure.Translator
{
    public static class ForecastProviderFactory
    {
        static public EForecast ConvertToForecastData(string provider, string json)
        {
            IForecastExtension oExtension = null;

            switch (provider)
            {
                case "1":
                    oExtension = new ForecastIOExtension();
                    break;
                case "2":
                    oExtension = new WeatherUndergroundExtension();
                    break;
                default:
                    oExtension = new ForecastIOExtension();
                    break;
            }
            return oExtension.GetForecastResponse(json);
        }

        static public string BuildRequestUrl(EProvider oProvider, ECity oCity)
        {
            IForecastExtension oExtension = null;

            switch (oProvider.Id)
            {
                case "1":
                    oExtension = new ForecastIOExtension();
                    break;
                case "2":
                    oExtension = new WeatherUndergroundExtension();
                    break;
                default:
                    oExtension = new ForecastIOExtension();
                    break;
            }
            return oExtension.GetForecastRequest(oProvider, oCity);
        }
    }
}
