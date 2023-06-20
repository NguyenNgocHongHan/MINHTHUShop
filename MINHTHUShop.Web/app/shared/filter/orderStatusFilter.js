(function (app) {
    app.filter('orderStatusFilter', function () {
        return function (input) {
            if (input == 1)
                return 'Đã hủy';
            else
                if (input == 2)
                    return 'Đang duyệt';
                else
                    if (input == 3)
                        return 'Đang đóng gói';
                    else
                        if (input == 4)
                            return 'Đang vận chuyển';
                        else
                            return 'Hoàn thành';
        }
    });
})(angular.module('MINHTHUShop.common'));