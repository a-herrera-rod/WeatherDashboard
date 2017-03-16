using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherDashboard.Webapi.Models
{
    public class FailureResponse : ResponseModel
    {
        public int? error_code { get; set; }
        public string error_msg { get; set; }

        public FailureResponse(int _code, string _msg)
            : base(false)
        {
            this.error_code = _code;
            this.error_msg = _msg;
        }
    }
}