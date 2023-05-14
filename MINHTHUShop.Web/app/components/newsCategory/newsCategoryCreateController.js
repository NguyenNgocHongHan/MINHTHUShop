(function (app) {
    app.controller('newsCategoryCreateController', newsCategoryCreateController);

    newsCategoryCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function newsCategoryCreateController($scope, $state, apiService, notificationService, commonService) {
        $scope.newsCategory = {}
        $scope.parentCategory = [];

        $scope.CreateNewsCategory = CreateNewsCategory;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.newsCategory.MetaTitle = commonService.getMetaTitle($scope.newsCategory.Name);
        }

        function LoadParentCategory() {
            apiService.get('api/NewsCategory/GetAll', null, function (result) {
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

        function CreateNewsCategory() {
            apiService.post('api/NewsCategory/Create', $scope.newsCategory,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('newsCategory');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        LoadParentCategory();
    }
})(angular.module('MINHTHUShop.newsCategory'));