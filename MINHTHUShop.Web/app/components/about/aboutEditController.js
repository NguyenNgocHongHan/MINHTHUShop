(function (app) {
    app.controller('aboutEditController', aboutEditController);

    aboutEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService'];

    function aboutEditController($scope, $state, $stateParams, apiService, notificationService) {
        $scope.about = {};

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.UpdateAbout = UpdateAbout;

        function UpdateAbout() {
            apiService.put('api/About/Update', $scope.about,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('about');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function LoadAboutDetail() {
            apiService.get('api/About/GetById/' + $stateParams.id, null, function (result) {
                $scope.about = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadAboutDetail();
    }
})(angular.module('MINHTHUShop.about'));