(function (app) {
    app.controller('faqCategoryCreateController', faqCategoryCreateController);

    faqCategoryCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function faqCategoryCreateController($scope, $state, apiService, notificationService, commonService) {
        $scope.faqCategory = {}
        $scope.parentCategory = [];

        $scope.CreateFAQCategory = CreateFAQCategory;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.faqCategory.MetaTitle = commonService.getMetaTitle($scope.faqCategory.Name);
        }

        function LoadParentCategory() {
            apiService.get('api/FAQCategory/GetAll', null, function (result) {
                /*console.log(result);*/
                $scope.parentCategory = result.data;
                /*$scope.parentCategory = commonService.getTree(result.data, "CateID", "ParentID");*/
                /*$scope.parentCategories.forEach(function (item) {
                    recur(item, 0, $scope.flatFolders);
                });*/
            }, function () {
                console.log('Không thể lấy ra danh sách thư mục cha!');
            });
        }

        function CreateFAQCategory() {
            apiService.post('api/FAQCategory/Create', $scope.faqCategory,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('faqCategory');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        LoadParentCategory();
    }
})(angular.module('MINHTHUShop.faqCategory'));