(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'Đang hoạt động';
            else
                return 'Ngừng hoạt động';
        }
    });
})(angular.module('MINHTHUShop.common'));