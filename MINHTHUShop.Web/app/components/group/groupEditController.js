(function (app) {
    'use strict';

    app.controller('groupEditController', groupEditController);

    groupEditController.$inject = ['$scope', '$state', '$stateParams', '$location', 'apiService', 'notificationService'];

    function groupEditController($scope, $state, $stateParams, $location, apiService, notificationService) {
        $scope.group = {};

        $scope.UpdateGroup = UpdateGroup;

        function UpdateGroup() {
            apiService.put('api/Group/Update', $scope.group, createSuccessed, createFailed);
        }

        function createSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được cập nhật thành công.');
            $location.url('group');
        }

        function createFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function LoadDetail() {
            apiService.get('api/Group/GetById/' + $stateParams.id, null,
                function (result) {
                    $scope.group = result.data;
                },
                function (result) {
                    notificationService.displayError(result.data);
                });
        }

        function LoadRoles() {
            apiService.get('/api/Role/GetAll', null,
                function (response) {
                    $scope.roles = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách các quyền.');
                });

        }

        LoadRoles();
        LoadDetail();
    }
})(angular.module('MINHTHUShop.group'));