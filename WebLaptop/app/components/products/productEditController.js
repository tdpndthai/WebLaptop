//(function (app) {
//    'use strict';
//    app.controller('productEditController', productEditController) //tên controller,phương thức
//    function productEditController() {

//    }
//})(angular.module('thaishop.products',[]));

//uirouter.controller('productEditController', productEditController);
//uirouter.$inject = ["$scope"];
//function productEditController() {

//}

//(function (app) {
//    app.controller('productAddController', productAddController) //tên controller,phương thức
//    function productAddController() {

//    }
//})(angular.module('thaishop.products',[]));

//uirouter.controller('productAddController', productAddController);
//uirouter.$inject = ["$scope"];
//function productAddController() {

//}

(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService','$stateParams'];

    function productEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.product = {};
        $scope.ckeditorOptions = {
            language: "vi",
            height: '200px'
        };

        function loadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data; //gán đối tượng product vào đối tượng vừa lấy được
            }, function (error) {
                console.log(error)
                notificationService.displayError(error.data);
            });
        }

        $scope.GetSeoTitle = GetSeoTitle;
        $scope.UpdateProduct = UpdateProduct;
        function UpdateProduct() {
            apiService.put('api/product/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được chỉnh sửa thành công');
                    $state.go('products');
                }, function (error) {
                    console.log(error)
                    notificationService.displayError('Chỉnh sửa không thành công')
                });
        }

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }


        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("Không load được parent list")
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            };
            finder.popup();
        }

        loadProductDetail();
        loadProductCategory();
    }
})(angular.module('thaishop.products'));