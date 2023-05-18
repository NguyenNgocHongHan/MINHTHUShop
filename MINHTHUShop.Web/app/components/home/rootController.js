(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$scope', '$state', 'authData', 'authService', 'loginService']

    function rootController($scope, $state, authData, authService, loginService) {
        $scope.Logout = function () {
            loginService.Logout();
            $state.go('login');
        }

        $scope.authentication = authData.authenticationData;
        //$scope.sideBar = "/app/shared/views/sideBar.html";
        /*authService.validateRequest();*/
    }
})(angular.module('MINHTHUShop'));