(function () {
    angular.module('thaishop.productCategory', ['thaishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product_categories', {
                url: "/product_categories",
                templateUrl: "/app/components/product_categories/productCategoryListView.html",
                controller: "productCategoryListController"
            })
            .state('product_categories_add', {
                url: "/add_product_category",
                templateUrl: "/app/components/product_categories/productCategoryAddView.html",
                controller: "productCategoryAddController"
            })
            .state('product_categories_edit', {
                url: "/edit_product_category/:id", //truyền tham số id vào 
                templateUrl: "/app/components/product_categories/productCategoryEditView.html",
                controller: "productCategoryEditController"
            });
    }
})();