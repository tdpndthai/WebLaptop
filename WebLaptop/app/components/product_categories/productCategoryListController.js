(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService','notificationService','$ngBootbox','$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProductCategory = getListProductCategory;
        $scope.keyWord = '';

        $scope.search = search;

        $scope.deleteProductCategory = deleteProductCategory;

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
                    checkedProductCategories: JSON.stringify(listId)
                }
            }
            apiService.del('api/productcategory/deletemulti', config, function (result) {
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
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        } 

        //lắng nghe sự thay đổi của list(select check) n:new, o: old,mỗi lần nhấn nút check thì xóa bỏ disabled trong thẻ html còn nếu ko thì thêm vào
        $scope.$watch('productCategories', function (n, o) {
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