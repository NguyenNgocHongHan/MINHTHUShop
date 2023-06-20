(function (app) {
    app.controller('faqEditController', faqEditController);

    faqEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function faqEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.faq = {}

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.UpdateFAQ = UpdateFAQ;
        $scope.GetMetaTitle = GetMetaTitle;

        function UpdateFAQ() {
            apiService.put('api/FAQ/Update', $scope.faq,
                function (result) {
                    notificationService.displaySuccess(result.data.Question + ' đã được cập nhật');
                    $state.go('faq');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function GetMetaTitle() {
            $scope.faq.MetaTitle = commonService.getMetaTitle($scope.faq.Question);
        }

        function LoadFAQDetail() {
            apiService.get('api/FAQ/GetById/' + $stateParams.id, null, function (result) {
                $scope.faq = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function LoadCate() {
            apiService.get('api/FAQCategory/GetAll', null, function (result) {
                $scope.faqCategory = result.data;
            }, function () {
                console.log('Tải danh mục FAQ thất bại!');
            });
        }

        LoadCate();
        LoadFAQDetail();
    }
})(angular.module('MINHTHUShop.faq'));