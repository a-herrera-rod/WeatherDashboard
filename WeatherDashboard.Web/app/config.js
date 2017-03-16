(function () {
    'use strict';

    angular
        .module('app')
        .config(config);

    function config($httpProvider) {
        var serviceCredentials = "Basic my_user:my_password";

        $httpProvider.defaults.headers.common = { 'Authorization': serviceCredentials };
        $httpProvider.defaults.headers.post = {};
        $httpProvider.defaults.headers.put = {};
        $httpProvider.defaults.headers.patch = {};
    }
    config.$inject = ['$httpProvider'];

})();