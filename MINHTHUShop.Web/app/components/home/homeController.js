(function (app) {
    app.controller('homeController', homeController);

    homeController.$inject = ['$state', 'apiService', 'notificationService']

    function homeController($state, apiService, notificationService) {
        function viewHome() {
            var config = {
                params: {}
            }
            apiService.get('api/Home/GetHome', config,
                function () {
                    console.log('Đăng nhập thành công');
                }, function () {
                    notificationService.displayWarning('Bạn không có quyền truy cập vào tài khoản!');
                    $state.go('login');
                });
        }

        viewHome();
    }

})(angular.module('MINHTHUShop'));