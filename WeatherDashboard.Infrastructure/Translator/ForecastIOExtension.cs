using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Model;
using Newtonsoft.Json.Linq;

namespace WeatherDashboard.Infrastructure.Translator
{
    class ForecastIOExtension: IForecastExtension
    {
        public EForecast GetForecastResponse(string sJson)
        {
            EForecast objResult = new EForecast();
            JObject jObject = JObject.Parse(sJson);

            //Current temperature data
            JToken jCurrent = jObject["currently"];
            objResult.Status = (string)jCurrent["summary"];
            objResult.Temperature = (string)jCurrent["temperature"];
            objResult.Icon = (string)jCurrent["icon"];

            //7 day forecast
            JToken jDaily = jObject["daily"];
            var jDailyForecast = JArray.Parse(jDaily["data"].ToString());

            objResult.DailyForecast = jDailyForecast.Select(item => new EDailyForecast
            {
                Status = item["summary"].ToString(),
                Day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(Convert.ToDouble(item["time"])).ToLocalTime().DayOfWeek.ToString(),
                Icon = item["icon"].ToString(),
                Temperature_maximum = item["temperatureMax"].ToString(),
                Temperature_minimum = item["temperatureMin"].ToString()
            }).ToList();
            
            objResult.DailyForecast.RemoveAt(0);         

            return objResult;
        }

        public string GetForecastRequest(EProvider oProvider, ECity oCity)
        {
            return String.Format(oProvider.Url, oProvider.Key, oCity.Latitude, oCity.Longitude);
        }
    }
}
