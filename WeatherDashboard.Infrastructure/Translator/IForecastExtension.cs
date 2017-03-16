using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Model;

namespace WeatherDashboard.Infrastructure.Translator
{
    interface IForecastExtension
    {
        EForecast GetForecastResponse(string sJson);
        string GetForecastRequest(EProvider oProvider, ECity oCity);
    }
}
