(function (app) {
    app.controller('orderStatusCreateController', orderStatusCreateController);

    orderStatusCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService'];

    function orderStatusCreateController($scope, $state, apiService, notificationService) {
        $scope.orderStatus = {}

        $scope.CreateOrderStatus = CreateOrderStatus;

        function CreateOrderStatus() {
            apiService.post('api/OrderStatus/Create', $scope.orderStatus,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('orderStatus');
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
})(angular.module('MINHTHUShop.orderStatus'));