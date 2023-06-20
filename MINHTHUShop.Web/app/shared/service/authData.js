(function (app) {
    'use strict'; //dùng để quản lý một cách nghiêm ngặt hơn về cú pháp
    app.factory('authData', [
        function () {
            var authDataFactory = {};

            //bắt sự kiện login xem tk đăng nhập chưa
            var authentication = {
                IsAuthenticated: false,
                userName: ""
            };
            authDataFactory.authenticationData = authentication;

            return authDataFactory;
        }]);
})(angular.module('MINHTHUShop.common'));