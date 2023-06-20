(function (app) {
    app.controller('shippingMethodEditController', shippingMethodEditController);

    shippingMethodEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService'];

    function shippingMethodEditController($scope, $state, $stateParams, apiService, notificationService) {
        $scope.shippingMethod = {};

        $scope.UpdateShippingMethod = UpdateShippingMethod;

        function UpdateShippingMethod() {
            apiService.put('api/ShippingMethod/Update', $scope.shippingMethod,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('shippingMethod');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function LoadShippingMethodDetail() {
            apiService.get('api/ShippingMethod/GetById/' + $stateParams.id, null, function (result) {
                $scope.shippingMethod = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadShippingMethodDetail();
    }
})(angular.module('MINHTHUShop.shippingMethod'));