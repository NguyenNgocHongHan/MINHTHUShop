(function (app) {
    'use strict';

    app.controller('userEditController', userEditController);

    userEditController.$inject = ['$scope', '$state', '$stateParams', '$location', 'apiService', 'notificationService'];

    function userEditController($scope, $state, $stateParams, $location, apiService, notificationService) {
        $scope.user = {};

        $scope.UpdateUser = UpdateUser;

        function UpdateUser() {
            apiService.put('api/User/Update', $scope.user, createSuccessed, createFailed);
        }

        function createSuccessed() {
            notificationService.displaySuccess($scope.user.Name + ' đã được cập nhật thành công.');
            $location.url('user');
        }

        function createFailed(response) {
            notificationService.displayError('Bạn không có quyền truy cập tính năng này!');
            notificationService.displayErrorValidation(response);
            $state.go('user');
        }

        function LoadDetail() {
            apiService.get('api/User/GetById/' + $stateParams.id, null,
                function (result) {
                    $scope.user = result.data;
                },
                function (result) {
                    notificationService.displayError(result.data);
                });
        }

        function LoadGroups() {
            apiService.get('/api/Group/GetAll', null,
                function (response) {
                    $scope.groups = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách các nhóm.');
                    $state.go('user');
                });

        }

        LoadGroups();
        LoadDetail();
    }
})(angular.module('MINHTHUShop.user'));