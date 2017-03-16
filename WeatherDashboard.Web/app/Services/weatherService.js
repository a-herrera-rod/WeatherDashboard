(function () {
    'use strict';

    angular
		.module('app.services')
		.service('weatherService', weatherService);
    weatherService.$inject = ["$http", "$timeout"];
    function weatherService($http, $timeout) {
        var getForecastCallback = null;
        var getProviderListCallback = null;
        var getCityListCallback = null;
        
        var requests = {
            getProviders : {
                method: 'GET',
                url: serviceUrl + 'WeatherProvider'
            },
            getCities: {
                method: 'GET',
                url: serviceUrl + 'City'
            },
            getWeather : {
                method: 'GET',
                url: serviceUrl + 'Forecast',
                params: { sProviderId: '', sCityId: '' }
            }
        }

        this.addGetProviderCallback = function (callback) {
            getProviderListCallback = callback;
        }

        this.addGetCityCallback = function (callback) {
            getCityListCallback = callback;
        }

        this.addGetForecastCallback = function (callback) {
            getForecastCallback = callback;
        }        

        this.getProviderList = function () {
            $http(requests.getProviders).then(getProvidersSuccess, getError);
        }

        this.getCityList = function () {
            $http(requests.getCities).then(getCitiesSuccess, getError);
        }

        this.getForecast = function (providerId, cityId) {
            requests.getWeather.params.sProviderId = providerId;
            requests.getWeather.params.sCityId = cityId;
            $http(requests.getWeather).then(getWeatherSuccess, getError);
        }

        var executeCallbacks = function(callback, parameters){
            if (callback != null) {
                callback.apply(null, parameters);
            }
        }

        var getError = function (response) {
            alert("An error has ocurred");
        }

        var getProvidersSuccess = function (response) {
            executeCallbacks(getProviderListCallback, [response.data.elements]);
        }

        var getCitiesSuccess = function (response) {
            executeCallbacks(getCityListCallback, [response.data.elements]);
        }

        var getWeatherSuccess = function (response) {
            executeCallbacks(getForecastCallback, [response.data.element]);
        }
    }
})();