using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherDashboard.Webapi.Models
{
    public class SuccessResponseList<Entity> : ResponseModel
    {
        public List<Entity> elements { get; set; }
        public int total_elements { get; set; }
        public SuccessResponseList(List<Entity> lstEntities)
            : base(true)
        {
            this.elements = lstEntities;
            this.total_elements = lstEntities.Count();
        }
    }
}