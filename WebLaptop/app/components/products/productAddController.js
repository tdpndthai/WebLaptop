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
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag: true
        }
        $scope.ckeditorOptions = {
            language: "vi",
            height:'200px'
        };

        $scope.AddProduct = AddProduct;
        function AddProduct() {
            apiService.post('api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới');
                    $state.go('product_categories');
                }, function (error) {
                    console.log(error)
                    notificationService.displayError('Thêm mới không thành công')
                });
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

        loadProductCategory();
    }
})(angular.module('thaishop.products'));