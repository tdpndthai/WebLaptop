//(function (app) {
//    'use strict';
//    app.controller('productListController', productListController) //tên controller,phương thức
//    function productListController() {

//    }
//})(angular.module('thaishop.products',[]));

//uirouter.controller('productListController', productListController);
//uirouter.$inject = ["$scope"];
//function productListController() {

//}

//(function (app) {
//    app.controller('productListController', productListController);

//    function productListController() {

//    }
//})(angular.module('thaishop.products'));


(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProducts = getListProducts;
        //$scope.getListProductCategories = getListProductCategories;
        $scope.keyWord = '';

        $scope.search = search;

        $scope.deleteProduct = deleteProduct;

        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            })
            var config = {
                params: {
                    //tên tham số ở đây phải trùng với tên tham số bên api
                    checkedProducts: JSON.stringify(listId)
                }
            }
            apiService.del('api/product/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                search();
            }, function (error) {
                notificationService.displayError('Xóa thành công không thành công')
            })
        }


        //mặc định ban đầu chưa check all,binding vào ng-model vào checked bên ngoài view
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll == false) {
                //nếu mà chưa isAll thì thêm thuộc tính checked vào
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        //lắng nghe sự thay đổi của list(select check) n:new, o: old,mỗi lần nhấn nút check thì xóa bỏ disabled trong thẻ html còn nếu ko thì thêm vào
        $scope.$watch('products', function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                //gom tất cả các selected
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            }
            else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/product/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        //hàm serach ,lấy danh sách với keyword,page,pagesize
        function search() {
            getListProducts();
        }

        //function getListProductCategories() {
        //    apiService.get('api/productcategory/getallparents', function (result) {
        //        $scope.productCategories = result.data;
        //    }, function (error) {
        //        console.log("load danh mục lỗi")
        //    });
        //}

        //lấy ra danh sách loại sản phẩm
        function getListProducts(page) {
            page = page || 0; //kiểm tra nếu page=null thì thay bằng 0
            var config = {
                params: {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize: 20
                }
            }
            //gọi đến phương thức api getall
            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không có bản ghi nào được tìm thấy");
                }
                //else {
                //    notificationService.displaySuccess("Có " + result.data.TotalCount +" bản ghi được tìm thấy");
                //}
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('load sản phẩm lỗi');
            });
        }
        //$scope.getListProductCategories();
        $scope.getListProducts();
    }
})(angular.module('thaishop.products'));
