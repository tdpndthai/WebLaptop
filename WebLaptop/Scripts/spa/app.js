/// <reference path="../plugins/angular/angular.js" />
//bài 1
//khởi tạo module
//var myApp = angular.module("myModule", []);

////khai báo 1 controller với module myApp tên là myController,constructor tùy cách đặt,viết tường minh
//myApp.controller("myController", myControll);

//myControll.$inject = ["$scope"]; //tiêm biến đối tượng scope vào controller

//function myControll($scope) {
//    $scope.message = "mesage form controller";
//}

//khai báo 1 controller với module myApp tên với hàm nặc danh
//myApp.controller("myController", ($scope) {
//    $scope.message = "mesage form controller"
//});

//bài 2 rootscope
//var app = angular.module("mymodule", []);
//app.controller("stcontroller", stcontroller);
//app.controller("tecontroller", tecontroller);
//app.$inject = ["$scope"];

////mỗi div chỉ nhận các controller đã register mặc dù cùng biến $scope nhưng 2 div khác nhau với 2 controller khách nhau
////thì thể hiện khác nhau
////$rootscope 1 controller khai báo thì tất cả các controller khác không khai báo nhưng vẫn có biến toàn cục đó

//function stcontroller($scope) {
//    $scope.message = "student";
//} function tecontroller($scope) {
//    $scope.message = "teacher";
//}


//bài 3: service

var myApp = angular.module('mymodule', []);

myApp.controller("schoolController", schoolController);
myApp.directive("thaiShopDirective", thaiShopDirective);
myApp.service('validatorService', validatorService);

schoolController.$inject = ['$scope', 'validatorService'];

function schoolController($scope, validatorService) {

    $scope.checkNumber = function () {
        $scope.message = Validator.checkNumber($scope.num);
    }
    $scope.num = 1;
}

function validatorService($window) {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            return 'This is even';
        }
        else
            return 'This is odd';
    }

}

//directive

function thaiShopDirective() {
    return {
        restrict:"A",
        templateUrl: "/Scripts/spa/thaiShopDirective.html"
    }
}



