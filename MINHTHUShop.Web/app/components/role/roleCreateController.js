(function (app) {
    'use strict';

    app.controller('roleCreateController', roleCreateController);

    roleCreateController.$inject = ['$scope', '$state', '$location', 'apiService', 'notificationService', 'commonService'];

    function roleCreateController($scope, $state, $location, apiService, notificationService, commonService) {
        $scope.role = {
            Id: 0
        }

        $scope.CreateRole = CreateRole;

        function CreateRole() {
            apiService.post('api/Role/Create', $scope.role, createSuccessed, createFailed);
        }

        function createSuccessed() {
            notificationService.displaySuccess('Đã thêm ' + $scope.role.Name + ' thành công');
            //điều hướng đến trang role
            $location.url('role');
        }

        function createFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function LoadRole() {
            apiService.get('/api/Role/GetAll', null,
                function (response) {
                    $scope.roles = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách quyền.');
                });
        }

        LoadRole();
    }
})(angular.module('MINHTHUShop.role'));