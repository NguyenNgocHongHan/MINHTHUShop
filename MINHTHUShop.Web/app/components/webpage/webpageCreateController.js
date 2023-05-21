(function (app) {
    app.controller('webpageCreateController', webpageCreateController);

    webpageCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function webpageCreateController($scope, $state, apiService, notificationService, commonService) {
        $scope.webpage = {
            CreateDate: new Date(),
            Status: true,
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.CreateWebpage = CreateWebpage;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.webpage.MetaTitle = commonService.getMetaTitle($scope.webpage.Name);
        }

        function CreateWebpage() {
            apiService.post('api/Webpage/Create', $scope.webpage,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('webpage');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }
    }
})(angular.module('MINHTHUShop.webpage'));