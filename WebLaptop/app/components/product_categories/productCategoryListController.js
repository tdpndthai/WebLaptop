(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService','notificationService','$ngBootbox'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProductCategory = getListProductCategory;
        $scope.keyWord = '';

        $scope.search = search;

        $scope.deleteProductCategory = deleteProductCategory;

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        //hàm serach ,lấy danh sách với keyword,page,pagesize
        function search() {
            getListProductCategory();
        }

        //lấy ra danh sách loại sản phẩm
        function getListProductCategory(page) {
            page = page || 0; //kiểm tra nếu page=null thì thay bằng 0
            var config = {
                params: {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize:20
                }
            }
            //gọi đến phương thức api getall
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không có bản ghi nào được tìm thấy");
                }
                //else {
                //    notificationService.displaySuccess("Có " + result.data.TotalCount +" bản ghi được tìm thấy");
                //}
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