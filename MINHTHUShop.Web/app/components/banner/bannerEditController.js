(function (app) {
    app.controller('bannerEditController', bannerEditController);

    bannerEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService'];

    function bannerEditController($scope, $state, $stateParams, apiService, notificationService) {
        $scope.banner = {};

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.UpdateBanner = UpdateBanner;

        function UpdateBanner() {
            apiService.put('api/Banner/Update', $scope.banner,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('banner');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function LoadBannerDetail() {
            apiService.get('api/Banner/GetById/' + $stateParams.id, null, function (result) {
                $scope.banner = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.banner.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.DeleteImage = function () {
            $scope.banner.Image = null;
        }


        LoadBannerDetail();
    }
})(angular.module('MINHTHUShop.banner'));