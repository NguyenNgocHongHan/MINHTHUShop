(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == 1)
                return 'Đang hoạt động';
            else
                return 'Ngừng hoạt động';
        }
    });
})(angular.module('MINHTHUShop.common'));