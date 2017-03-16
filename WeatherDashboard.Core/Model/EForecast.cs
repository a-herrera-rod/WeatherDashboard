using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Utils;

namespace WeatherDashboard.Core.Model
{
    public class EForecast
    {        
        public string Status { get; set; }
        public string Temperature { get; set; }
        private string _icon;
        public string Icon {
            get
            {
                return this._icon;
            }
            set
            {
                _icon = Parsers.ParseIcon(value);
            }
        }
        private List<EDailyForecast> _lstDailyForecast;
        public List<EDailyForecast> DailyForecast
        {
            get
            {
                if (_lstDailyForecast == null)
                {
                    _lstDailyForecast = new List<EDailyForecast>();
                }
                return this._lstDailyForecast;
            }
            set
            {                
                _lstDailyForecast = value;
            }
        }
    }
}
