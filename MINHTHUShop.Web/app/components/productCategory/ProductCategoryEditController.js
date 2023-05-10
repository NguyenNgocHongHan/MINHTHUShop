(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function productCategoryEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.productCategory = {};
        $scope.parentCategory = [];

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetMetaTitle = GetMetaTitle;

        function UpdateProductCategory() {
            apiService.put('api/ProductCategory/Update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('productCategory');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function GetMetaTitle() {
            $scope.productCategory.MetaTitle = commonService.getMetaTitle($scope.productCategory.Name);
        }

        function LoadParentCategory() {
            apiService.get('api/ProductCategory/GetAll', null, function (result) {
                $scope.parentCategory = result.data;
            }, function () {
                console.log('Không thể lấy ra danh sách thư mục cha!');
            });
        }

        function LoadProductCategoryDetail() {
            apiService.get('api/ProductCategory/GetById/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadParentCategory();
        LoadProductCategoryDetail();
    }
})(angular.module('MINHTHUShop.productCategory'));