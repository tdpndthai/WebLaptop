(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProductCategory = getListProductCategory;
        $scope.keyWord = '';

        $scope.search = search;

        function search() {
            getListProductCategory();
        }

        function getListProductCategory(page) {
            page = page || 0; //kiểm tra nếu page=null thì thay bằng 0
            var config = {
                params: {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize:20
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('load danh mục sản phẩm lỗi');
            });
        }
        $scope.getListProductCategory();
    }
})(angular.module('thaishop.productCategory'));