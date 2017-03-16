using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherDashboard.Webapi.Models
{
    public class SuccessResponse<Entity> : ResponseModel
    {
        public Entity element { get; set; }
        public SuccessResponse(Entity entity)
            : base(true)
        {
            this.element = entity;
        }
    }
}