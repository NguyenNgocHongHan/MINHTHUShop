(function (app) {
    app.controller('productCategoryCreateController', productCategoryCreateController);

    productCategoryCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function productCategoryCreateController($scope, $state, apiService, notificationService, commonService) {
        $scope.productCategory = {}
        $scope.parentCategory = [];

        $scope.CreateProductCategory = CreateProductCategory;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.productCategory.MetaTitle = commonService.getMetaTitle($scope.productCategory.Name);
        }

        function LoadParentCategory() {
            apiService.get('api/ProductCategory/GetAllParentCate', null, function (result) {
                /*console.log(result);*/
                $scope.parentCategory = result.data;
                /*$scope.parentCategory = commonService.getTree(result.data, "CateID", "ParentID");*/
                /*$scope.parentCategories.forEach(function (item) {
                    recur(item, 0, $scope.flatFolders);
                });*/
            }, function () {
                console.log('Không thể lấy ra danh sách thư mục cha!');
            });
        }

        function CreateProductCategory() {
            apiService.post('api/ProductCategory/Create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('productCategory');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        LoadParentCategory();
    }
})(angular.module('MINHTHUShop.productCategory'));