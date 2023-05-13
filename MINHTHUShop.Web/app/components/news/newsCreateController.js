(function (app) {
    app.controller('newsCreateController', newsCreateController);

    newsCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function newsCreateController($scope, $state, apiService, notificationService, commonService) {
        $scope.news = {
            CreateDate: new Date(),
            Status: true,
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.CreateNews = CreateNews;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.news.MetaTitle = commonService.getMetaTitle($scope.news.Name);
        }

        function CreateNews() {
            apiService.post('api/News/Create', $scope.news,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' vào danh mục tin tức');
                    //điều hướng đến trang mới
                    $state.go('news');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        function LoadCate() {
            apiService.get('api/NewsCategory/GetAll', null, function (result) {
                $scope.newsCategory = result.data;
            }, function () {
                console.log('Tải sản danh mục sản phẩm thất bại!');
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

        LoadCate();
    }
})(angular.module('MINHTHUShop.news'));