===================== Overview =====================
This web application will show the current weather 
in a specific city and a 7 day forecast for the 
upcomming days according to one of the public 
weather service selected.

============ Available weather services ============
-Forecast.IO (https://darksky.net/)
-Weather Undergroung (https://www.wunderground.com/)

=================== Architecture ===================
> WeatherDashboard.Core
  Contains the basic models and interfaces for the 
  backend application.

> WeatherDashboard.Infrastructure
  Contains the backend logic for handling data and 
  external services connection.

> WeatherDashboard.DependencyInjection
  Handles the dependency injection for the 
  components mentioned above and the WebApi service
  using Ninject.

> WeatherDashboard.Webapi
  Contains the API controllers to handle the requests
  from the main UI and an entrypoint to the backend 
  methods implemented. Also includes basic 
  authentication and validation for the requests.

> WeatherDashboard.Webapi.Tests 
  Provides unit test methods for the backend functions
  using Moq.

> WeatherDashboard.Web
  The frontend of the application (UI). Works with
  AngularJS 1.6.2, and contains the view, controllers
  and services required to connect to the WebAPI
  services.