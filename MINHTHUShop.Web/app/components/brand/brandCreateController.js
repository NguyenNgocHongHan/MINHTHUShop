(function (app) {
    app.controller('brandCreateController', brandCreateController);

    brandCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService'];

    function brandCreateController($scope, $state, apiService, notificationService) {
        $scope.brand = {}

        $scope.CreateBrand = CreateBrand;

        function CreateBrand() {
            apiService.post('api/Brand/Create', $scope.brand,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('brand');
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
})(angular.module('MINHTHUShop.brand'));