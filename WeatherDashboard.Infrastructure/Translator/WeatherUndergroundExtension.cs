using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WeatherDashboard.Core.Model;

namespace WeatherDashboard.Infrastructure.Translator
{
    public class WeatherUndergroundExtension: IForecastExtension
    {
        public EForecast GetForecastResponse(string sJson)
        {
            EForecast objResult = new EForecast();
            JObject jObject = JObject.Parse(sJson);
                                   
            JToken jDaily = jObject["forecast"]["simpleforecast"];
            var jDailyForecast = JArray.Parse(jDaily["forecastday"].ToString());

            List<EDailyForecast> lstDailyForecast = jDailyForecast.Select(item => new EDailyForecast
            {
                Status = item["conditions"].ToString(),
                Day = item["date"]["weekday"].ToString(),
                Icon = item["icon"].ToString(),
                Temperature_maximum = item["high"]["fahrenheit"].ToString(),
                Temperature_minimum = item["low"]["fahrenheit"].ToString()
            }).ToList();

            objResult.Status = lstDailyForecast[0].Status;
            objResult.Temperature = lstDailyForecast[0].Temperature_maximum.Length > 0 ? lstDailyForecast[0].Temperature_maximum : lstDailyForecast[0].Temperature_minimum;
            objResult.Icon = lstDailyForecast[0].Icon;

            for (int index = 1; index <= 7; index++)
            {
                objResult.DailyForecast.Add(lstDailyForecast[index]);
            }
            
            return objResult;
        }

        public string GetForecastRequest(EProvider oProvider, ECity oCity)
        {
            return String.Format(oProvider.Url, oProvider.Key, oCity.Country, oCity.Name);
        }
    }
}
