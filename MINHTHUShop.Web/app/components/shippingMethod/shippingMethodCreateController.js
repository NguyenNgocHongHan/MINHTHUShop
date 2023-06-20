(function (app) {
    app.controller('shippingMethodCreateController', shippingMethodCreateController);

    shippingMethodCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService'];

    function shippingMethodCreateController($scope, $state, apiService, notificationService) {
        $scope.shippingMethod = {}

        $scope.CreateShippingMethod = CreateShippingMethod;

        function CreateShippingMethod() {
            apiService.post('api/ShippingMethod/Create', $scope.shippingMethod,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('shippingMethod');
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
})(angular.module('MINHTHUShop.shippingMethod'));