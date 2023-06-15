(function (app) {
    app.filter('statusUserFilter', function () {
        return function (input) {
            if (input == true)
                return 'Được cấp phép';
            else
                return 'Không được cấp phép';
        }
    });
})(angular.module('MINHTHUShop.common'));