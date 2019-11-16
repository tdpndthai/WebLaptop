(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams','commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data; //gán đối tượng productcategory vào đối tượng vừa lấy được
            }, function (error) {
                console.log(error)
                    notificationService.displayError(error.data);
            });
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess('Tên danh mục '+ result.data.Name + ' đã được cập nhật thành công');
                    $state.go('product_categories');
                }, function (error) {
                    console.log(error)
                    notificationService.displayError('Cập nhật không thành công')
                });
        }


        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log("Không load được parent list")
            });
        }

        loadParentCategory();
        loadProductCategoryDetail();
    }

})(angular.module('thaishop.productCategory'))