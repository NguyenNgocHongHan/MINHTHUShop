(function (app) {
    'use strict';

    app.controller('groupCreateController', groupCreateController);

    groupCreateController.$inject = ['$scope', '$state', '$location', 'apiService', 'notificationService', 'commonService'];

    function groupCreateController($scope, $state, $location, apiService, notificationService, commonService) {
        $scope.group = {
            GroupID: 0,
            RoleVMs: []
        }

        $scope.CreateGroup = CreateGroup;

        function CreateGroup() {
            apiService.post('api/Group/Create', $scope.group, createSuccessed, createFailed);
        }

        function createSuccessed() {
            notificationService.displaySuccess('Đã thêm ' + $scope.group.Name + ' thành công');
            //điều hướng đến trang group
            $location.url('group');
        }

        function createFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function LoadRole() {
            apiService.get('/api/Role/GetAll',
                null,
                function (response) {
                    $scope.roles = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách quyền.');
                });
        }

        LoadRole();
    }
})(angular.module('MINHTHUShop.group'));