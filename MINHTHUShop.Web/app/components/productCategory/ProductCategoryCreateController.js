(function (app) {
    app.controller('productCategoryCreateController', productCategoryCreateController);

    productCategoryCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService'/*, 'commonService'*/];

    function productCategoryCreateController($scope, $state, apiService, notificationService/*, commonService*/) {
        $scope.productCategory = [];
        $scope.parentCategory = [];

        $scope.createProductCategory = createProductCategory;

        function loadParentCategory() {
            apiService.get('api/ProductCategory/GetAll', null, function (result) {
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

        function createProductCategory() {
            apiService.post('api/ProductCategory/Create', $scope.productCategory, function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' vào danh mục sản phẩm');
                    //điều hướng đến trang mới
                    $state.go('productCategory');
            }, function (error) {
                notificationService.displayError(error);
                });
        }

        loadParentCategory();
 /*        $scope.flatFolders = [];
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }


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
})(angular.module('MINHTHUShop.productCategory'));