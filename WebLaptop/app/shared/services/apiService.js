/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService', 'authenticationService']; //http là service có sẵn của angular
    function apiService($http, notificationService, authenticationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }

        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status == 401) {
                    notificationService.displayError('Yêu cầu đăng nhập vì bạn chưa có quyền')
                }
                else if (error.status == 500) {
                    notificationService.displayError('Lỗi gì đó mà dev méo biết được đâu')
                }
                else if(failure != null) {
                    failure(error);
                }
            });
        }

        function del(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status == 401) {
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
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status == 401) {
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
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('thaishop.common'));