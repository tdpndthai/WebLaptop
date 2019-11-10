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
    angular.module('thaishop', ['thaishop.products', 'thaishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();