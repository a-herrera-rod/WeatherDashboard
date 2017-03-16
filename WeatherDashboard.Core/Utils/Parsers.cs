using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDashboard.Core.Utils
{
    public static class Parsers
    {
        public static string ParseIcon(string _icon)
        {
            if (_icon.Contains("clear"))
            {
                return "clear";
            }
            if (_icon.Contains("cloud"))
            {
                return "cloud";
            }
            if (_icon.Contains("rain"))
            {
                return "rain";
            }
            if (_icon.Contains("storm"))
            {
                return "storm";
            }
            if (_icon.Contains("wind"))
            {
                return "wind";
            }
            return "no";
        }
    }
}
