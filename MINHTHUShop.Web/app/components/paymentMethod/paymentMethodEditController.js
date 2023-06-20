(function (app) {
    app.controller('paymentMethodEditController', paymentMethodEditController);

    paymentMethodEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService'];

    function paymentMethodEditController($scope, $state, $stateParams, apiService, notificationService) {
        $scope.paymentMethod = {};

        $scope.UpdatePaymentMethod = UpdatePaymentMethod;

        function UpdatePaymentMethod() {
            apiService.put('api/PaymentMethod/Update', $scope.paymentMethod,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('paymentMethod');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function LoadPaymentMethodDetail() {
            apiService.get('api/PaymentMethod/GetById/' + $stateParams.id, null, function (result) {
                $scope.paymentMethod = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadPaymentMethodDetail();
    }
})(angular.module('MINHTHUShop.paymentMethod'));