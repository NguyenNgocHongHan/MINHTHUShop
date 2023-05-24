(function (app) {
    app.controller('newsEditController', newsEditController);

    newsEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function newsEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.news = {}

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.UpdateNews = UpdateNews;
        $scope.GetMetaTitle = GetMetaTitle;

        function UpdateNews() {
            apiService.put('api/News/Update', $scope.news,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('news');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function GetMetaTitle() {
            $scope.news.MetaTitle = commonService.getMetaTitle($scope.news.Name);
        }

        function LoadNewsDetail() {
            apiService.get('api/News/GetById/' + $stateParams.id, null, function (result) {
                $scope.news = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function LoadCate() {
            apiService.get('api/NewsCategory/GetAll', null, function (result) {
                $scope.newsCategory = result.data;
            }, function () {
                console.log('Tải danh mục tin tức thất bại!');
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.news.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.DeleteImage = function () {
            $scope.news.Image = null;
        }

        LoadCate();
        LoadNewsDetail();
    }
})(angular.module('MINHTHUShop.news'));