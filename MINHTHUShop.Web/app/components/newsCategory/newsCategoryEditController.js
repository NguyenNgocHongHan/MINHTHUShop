(function (app) {
    app.controller('newsCategoryEditController', newsCategoryEditController);

    newsCategoryEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function newsCategoryEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.newsCategory = {};
        $scope.parentCategory = [];

        $scope.UpdateNewsCategory = UpdateNewsCategory;
        $scope.GetMetaTitle = GetMetaTitle;

        function UpdateNewsCategory() {
            apiService.put('api/NewsCategory/Update', $scope.newsCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('newsCategory');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function GetMetaTitle() {
            $scope.newsCategory.MetaTitle = commonService.getMetaTitle($scope.newsCategory.Name);
        }

        function LoadParentCategory() {
            apiService.get('api/NewsCategory/GetAll', null, function (result) {
                $scope.parentCategory = result.data;
            }, function () {
                console.log('Không thể lấy ra danh sách thư mục cha!');
            });
        }

        function LoadNewsCategoryDetail() {
            apiService.get('api/NewsCategory/GetById/' + $stateParams.id, null, function (result) {
                $scope.newsCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadParentCategory();
        LoadNewsCategoryDetail();
    }
})(angular.module('MINHTHUShop.newsCategory'));