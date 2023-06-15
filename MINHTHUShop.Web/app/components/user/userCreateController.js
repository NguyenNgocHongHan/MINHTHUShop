(function (app) {
    'use strict';

    app.controller('userCreateController', userCreateController);

    userCreateController.$inject = ['$scope', '$state', '$location', 'apiService', 'notificationService', 'commonService'];

    function userCreateController($scope, $state, $location, apiService, notificationService, commonService) {
        $scope.user = {
            GroupVMs: []
        }

        $scope.CreateUser = CreateUser;

        function CreateUser() {
            apiService.post('api/User/Create', $scope.user, createSuccessed, createFailed);
        }

        function createSuccessed() {
            notificationService.displaySuccess('Đã thêm ' + $scope.user.Name + ' thành công');
            //điều hướng đến trang user
            $location.url('user');
        }

        function createFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function LoadGroup() {
            apiService.get('/api/Group/GetAll', null,
                function (response) {
                    $scope.groups = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách quyền.');
                });
        }

        LoadGroup();
    }
})(angular.module('MINHTHUShop.user'));