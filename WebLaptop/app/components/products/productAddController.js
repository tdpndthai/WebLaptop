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
            height: '200px'
        };
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.AddProduct = AddProduct;
        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages)//gán list ảnh vừa thêm mới
            apiService.post('api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới');
                    $state.go('products');
                }, function (error) {
                    console.log(error)
                    notificationService.displayError('Thêm mới không thành công')
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
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            };
            finder.popup();
        }
        $scope.moreImages = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {//$apply cho ảnh hiển thị ngay tức thì
                    $scope.moreImages.push(fileUrl);
                })
            };
            finder.popup();
        };
        loadProductCategory();
    }
})(angular.module('thaishop.products'));