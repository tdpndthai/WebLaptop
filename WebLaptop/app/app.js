///// <reference path="../assets/admin/libs/angular/angular.js" />
//(function () {
//    'use strict';
//    //khởi tạo module
//    angular.module('thaishop', ['thaishop.products','thaishop.common']).config(config);

//    config.$inject = ["$stateProvider", "$urlRouterProvider"];
//    function config($stateProvider, $urlRouterProvider) {
//        $stateProvider.state('home', {
//            url: "/admin",
//            templateUrl: "/app/components/home/homeView.html",
//            controller: "homeController"
//        });
//        //nếu ko phải trường hợp nào thì trả về admin
//        $urlRouterProvider.otherwise('/admin');
//    }
//})();

//var uirouter1 = angular.module('thaishop', ['uirouter']);

//uirouter.config(function ($stateProvider, $urlRouterProvider) {
//    $stateProvider.state('home', {
//            url: "/admin",
//            templateUrl: "/app/components/home/homeView.html",
//            controller: "homeController"
//    });
//    $urlRouterProvider.otherwise('/admin');
//})();

(function () {
    angular.module('thaishop', ['thaishop.products', 'thaishop.productCategory', 'thaishop.common']).config(config).config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            })
            .state('login', {
                url: "/login",
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();