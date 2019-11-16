/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService']; //http là service có sẵn của angular
    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status == 400) {
                    notificationService.displayError('Yêu cầu đăng nhập vì bạn chưa có quyền')
                }
                else if (error.status == 500) {
                    notificationService.displayError('Lỗi gì đó mà dev méo biết được đâu')
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        function put(url, data, success, failure) {
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status == 400) {
                    notificationService.displayError('Yêu cầu đăng nhập vì bạn chưa có quyền')
                }
                else if (error.status == 500) {
                    notificationService.displayError('Lỗi gì đó mà dev méo biết được đâu')
                }
                else if (failure != null) {
                    failure(error);
                }
            });
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