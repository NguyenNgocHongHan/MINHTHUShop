(function (app) {
    app.controller('orderStatusEditController', orderStatusEditController);

    orderStatusEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService'];

    function orderStatusEditController($scope, $state, $stateParams, apiService, notificationService) {
        $scope.orderStatus = {};

        $scope.UpdateOrderStatus = UpdateOrderStatus;

        function UpdateOrderStatus() {
            apiService.put('api/OrderStatus/Update', $scope.orderStatus,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('orderStatus');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function LoadOrderStatusDetail() {
            apiService.get('api/OrderStatus/GetById/' + $stateParams.id, null, function (result) {
                $scope.orderStatus = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadOrderStatusDetail();
    }
})(angular.module('MINHTHUShop.orderStatus'));