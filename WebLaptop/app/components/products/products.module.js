
//(function () {
//    'use strict';
//    //khởi tạo module
//    angular.module('thaishop.products', ['thaishop.common']).config(config);

//    config.$inject = ['$stateProvider', '$urlRouterProvider'];
//    function config($stateProvider, $urlRouterProvider) {
//        $stateProvider.state('products', {
//            url: "/products",
//            templateUrl: "/app/components/products/productListView.html",
//            controller: "productListController"
//        }).state('products_add', {
//            url: "/products_add",
//            templateUrl: "/app/components/products/productAddView.html",
//            controller: "productAddController"
//        });
//    }
//})();

//uirouter.config(function ($stateProvider, $urlRouterProvider) {
//    $stateProvider
//        .state('products', {
//            url: "/products",
//            templateUrl: "/app/components/products/productListView.html",
//            controller: "productListController"
//        })
//        .state('products_add', {
//            url: "/products_add",
//            templateUrl: "/app/components/products/productAddView.html",
//            controller: "productAddController"
//        });
//    $urlRouterProvider.otherwise('/admin');
//})();


(function () {
    angular.module('thaishop.products', ['thaishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', { //trạng thái gọi trong sref
            url: "/products", //đường dẫn trên url
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        }).state('products_add', {
            url: "/products_add",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        }).state('product_edit', {
            url: "/product_edit/:id",
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditController"
        });
    }
})();