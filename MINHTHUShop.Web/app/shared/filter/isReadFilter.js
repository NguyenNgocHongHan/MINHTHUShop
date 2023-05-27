(function (app) {
    app.filter('isReadFilter', function () {
        return function (input) {
            if (input == true)
                return 'Đã đọc';
            else
                return 'Chưa đọc';
        }
    });
})(angular.module('MINHTHUShop.common'));