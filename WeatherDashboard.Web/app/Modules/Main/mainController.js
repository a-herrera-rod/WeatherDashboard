(function () {
    'use strict';

    angular
		.module('app')
		.controller('mainController', mainController);

    mainController.$inject = ["$rootScope", "$scope", "$timeout", "$window", "weatherService"];
    function mainController($rootScope, $scope, $timeout, window, weatherService) {
        $scope.providerList = null;
        $scope.cityList = null;
        $scope.selectedProvider = null;
        $scope.selectedCity = null;
        $scope.forecast = null;
        $scope.unit = "F";

        $scope.init = function () {
            weatherService.getCityList();
            weatherService.getProviderList();            
        };

        $scope.getForecast = function () {
            if ($scope.selectedCity != null && $scope.selectedProvider != null) {
                weatherService.getForecast($scope.selectedProvider.getId(), $scope.selectedCity.getId());
            }
        };

        $scope.changeUnits = function () {
            if ($scope.unit == "F") {
                $scope.unit = "C";                
            }
            else {
                $scope.unit = "F";
            }
        }

        function handleGetCityList(response) {
            $scope.cityList = [];            
            for (var i = 0; i < response.length; i++) {
                $scope.cityList.push(new City(response[i]));
            }
            if ($scope.cityList.length > 0) {
                $scope.selectedCity = $scope.cityList[0];
            }
            $scope.getForecast();
        }

        function handleGetProviderList(response) {            
            $scope.providerList = [];
            for (var i = 0; i < response.length; i++) {
                $scope.providerList.push(new Provider(response[i]));
            }
            if ($scope.providerList.length > 0) {
                $scope.selectedProvider = $scope.providerList[0];
            }
            $scope.getForecast();
        };

        function handleGetWeatherForecast(response) {
            $timeout(function () {
                $scope.forecast = (new Forecast(response));
            }, 0);
            
        };

        weatherService.addGetProviderCallback(handleGetProviderList);
        weatherService.addGetCityCallback(handleGetCityList);
        weatherService.addGetForecastCallback(handleGetWeatherForecast);
    }
})();