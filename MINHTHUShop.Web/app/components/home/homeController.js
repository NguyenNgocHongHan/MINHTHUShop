(function (app) {
    app.controller('homeController', homeController);

    homeController.$inject = ['$state', 'apiService', 'notificationService']

    function homeController($state, apiService, notificationService) {
        function viewHome() {
            apiService.get('api/Home/GetHome', null,
                function () {
                    console.log('Đăng nhập thành công');
                }, function () {
                    notificationService.displayWarning('Bạn không có quyền truy cập vào ứng dụng này!');
                    $state.go('login');
                });
        }

        viewHome();
    }

})(angular.module('MINHTHUShop'));