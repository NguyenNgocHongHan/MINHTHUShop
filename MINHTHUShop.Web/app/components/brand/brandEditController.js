(function (app) {
    app.controller('brandEditController', brandEditController);

    brandEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService'];

    function brandEditController($scope, $state, $stateParams, apiService, notificationService) {
        $scope.brand = {};
/*        $scope.parent = [];
*/
        $scope.UpdateBrand = UpdateBrand;

        function UpdateBrand() {
            apiService.put('api/Brand/Update', $scope.brand,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('brand');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

/*        function LoadParent() {
            apiService.get('api/Brand/GetAll', null, function (result) {
                $scope.parent = result.data;
            }, function () {
                console.log('Không thể lấy ra danh sách thương hiệu / hãng sản xuất!');
            });
        }
*/
        function LoadBrandDetail() {
            apiService.get('api/Brand/GetById/' + $stateParams.id, null, function (result) {
                $scope.brand = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

/*        LoadParent();
*/        LoadBrandDetail();
    }
})(angular.module('MINHTHUShop.brand'));