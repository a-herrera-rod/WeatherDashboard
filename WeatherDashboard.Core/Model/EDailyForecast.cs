using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Core.Utils;

namespace WeatherDashboard.Core.Model
{
    public class EDailyForecast
    {        
        public string Status { get; set; }
        public string Day { get; set; }
        public string Temperature_minimum { get; set; }
        public string Temperature_maximum { get; set; }
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
    }
}
