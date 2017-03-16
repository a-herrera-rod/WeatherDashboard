using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WeatherDashboard.Core.Interfaces.Repository;
using WeatherDashboard.Infrastructure.Repository;

namespace WeatherDashboard.Infrastructure.DependencyInjection
{
    public class RepositoryModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IWeatherDashboardRepository>().To<WeatherDashboardImplementationRepository>();
        }
    }
}
