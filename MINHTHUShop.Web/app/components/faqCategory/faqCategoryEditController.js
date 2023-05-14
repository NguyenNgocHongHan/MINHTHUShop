(function (app) {
    app.controller('faqCategoryEditController', faqCategoryEditController);

    faqCategoryEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function faqCategoryEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.faqCategory = {};
        $scope.parentCategory = [];

        $scope.UpdateFAQCategory = UpdateFAQCategory;
        $scope.GetMetaTitle = GetMetaTitle;

        function UpdateFAQCategory() {
            apiService.put('api/FAQCategory/Update', $scope.faqCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('faqCategory');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function GetMetaTitle() {
            $scope.faqCategory.MetaTitle = commonService.getMetaTitle($scope.faqCategory.Name);
        }

        function LoadParentCategory() {
            apiService.get('api/FAQCategory/GetAll', null, function (result) {
                $scope.parentCategory = result.data;
            }, function () {
                console.log('Không thể lấy ra danh sách thư mục cha!');
            });
        }

        function LoadFAQCategoryDetail() {
            apiService.get('api/FAQCategory/GetById/' + $stateParams.id, null, function (result) {
                $scope.faqCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        LoadParentCategory();
        LoadFAQCategoryDetail();
    }
})(angular.module('MINHTHUShop.faqCategory'));