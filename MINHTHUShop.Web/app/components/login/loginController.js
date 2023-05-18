(function (app) {
    app.controller('loginController', ['$scope', '$injector', 'loginService', 'notificationService',
        function ($scope, $injector, loginService, notificationService) {
            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.LoginSubmit = function () {
                loginService.Login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.data.error != undefined) {
                        notificationService.displayError("Tài khoản hoặc mật khẩu không chính xác!"/*response.data.error_description*/);
                    }
                    else {
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                });
            }
        }]);
})(angular.module('MINHTHUShop'));