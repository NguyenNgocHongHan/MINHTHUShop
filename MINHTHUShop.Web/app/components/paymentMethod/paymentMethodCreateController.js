(function (app) {
    app.controller('paymentMethodCreateController', paymentMethodCreateController);

    paymentMethodCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService'];

    function paymentMethodCreateController($scope, $state, apiService, notificationService) {
        $scope.paymentMethod = {}

        $scope.CreatePaymentMethod = CreatePaymentMethod;

        function CreatePaymentMethod() {
            apiService.post('api/PaymentMethod/Create', $scope.paymentMethod,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('paymentMethod');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        /*        $scope.flatFolders = [];
       
       
       
               function times(n, str) {
                   var result = '';
                   for (var i = 0; i < n; i++) {
                       result += str;
                   }
                   return result;
               };
               function recur(item, level, arr) {
                   arr.push({
                       Name: times(level, '–') + ' ' + item.Name,
                       ID: item.ID,
                       Level: level,
                       Indent: times(level, '–')
                   });
                   if (item.children) {
                       item.children.forEach(function (item) {
                           recur(item, level + 1, arr);
                       });
                   }
               };*/
    }
})(angular.module('MINHTHUShop.paymentMethod'));