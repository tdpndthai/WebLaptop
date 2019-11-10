/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http']; //http là service có sẵn của angular
    function apiService($http) {
        return {
            get: get
        }
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('thaishop.common'));