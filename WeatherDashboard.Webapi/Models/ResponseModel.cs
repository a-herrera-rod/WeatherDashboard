using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherDashboard.Webapi.Models
{
    public abstract class ResponseModel
    {
        public bool success;

        public ResponseModel(bool _success)
        {
            this.success = _success;
        }
    }
}