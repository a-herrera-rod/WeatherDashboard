using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WeatherDashboard.Core.Interfaces.Service;
using WeatherDashboard.Infrastructure.Services;

namespace WeatherDashboard.Infrastructure.DependencyInjection
{
    public class ServiceModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IWeatherDashboardService>().To<WeatherDashboardImplementationService>();
        }
    }
}
