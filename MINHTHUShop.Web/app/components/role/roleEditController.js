(function (app) {
    'use strict';

    app.controller('roleEditController', roleEditController);

    roleEditController.$inject = ['$scope', '$state', '$stateParams', '$location', 'apiService', 'notificationService'];

    function roleEditController($scope, $state, $stateParams, $location, apiService, notificationService) {
        $scope.role = {};

        $scope.UpdateRole = UpdateRole;

        function UpdateRole() {
            apiService.put('api/Role/Update', $scope.role, createSuccessed, createFailed);
        }

        function createSuccessed() {
            notificationService.displaySuccess($scope.role.Name + ' đã được cập nhật thành công.');
            $location.url('role');
        }

        function createFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function LoadDetail() {
            apiService.get('api/Role/GetById/' + $stateParams.id, null,
                function (result) {
                    $scope.role = result.data;
                },
                function (result) {
                    notificationService.displayError(result.data);
                });
        }

        LoadDetail();
    }
})(angular.module('MINHTHUShop.role'));