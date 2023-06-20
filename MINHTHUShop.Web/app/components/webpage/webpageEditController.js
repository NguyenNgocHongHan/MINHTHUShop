(function (app) {
    app.controller('webpageEditController', webpageEditController);

    webpageEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function webpageEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.webpage = {}

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.UpdateWebpage = UpdateWebpage;
        $scope.GetMetaTitle = GetMetaTitle;

        function UpdateWebpage() {
            apiService.put('api/Webpage/Update', $scope.webpage,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('webpage');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function GetMetaTitle() {
            $scope.webpage.MetaTitle = commonService.getMetaTitle($scope.webpage.Name);
        }

        function LoadWebpageDetail() {
            apiService.get('api/Webpage/GetById/' + $stateParams.id, null, function (result) {
                $scope.webpage = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadWebpageDetail();
    }
})(angular.module('MINHTHUShop.webpage'));