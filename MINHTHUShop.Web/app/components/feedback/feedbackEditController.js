(function (app) {
    app.controller('feedbackEditController', feedbackEditController);

    feedbackEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function feedbackEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.feedback = {}

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.UpdateFeedback = UpdateFeedback;

        function UpdateFeedback() {
            apiService.put('api/Feedback/Update', $scope.feedback,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('feedback');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function LoadFeedbackDetail() {
            apiService.get('api/Feedback/GetById/' + $stateParams.id, null, function (result) {
                $scope.feedback = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadFeedbackDetail();
    }
})(angular.module('MINHTHUShop.feedback'));