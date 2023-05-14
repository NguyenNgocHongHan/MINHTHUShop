(function (app) {
    app.controller('faqCreateController', faqCreateController);

    faqCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function faqCreateController($scope, $state, apiService, notificationService, commonService) {
        $scope.faq = {
            CreateDate: new Date(),
            Status: true,
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.CreateFAQ = CreateFAQ;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.faq.MetaTitle = commonService.getMetaTitle($scope.faq.Question);
        }

        function CreateFAQ() {
            apiService.post('api/FAQ/Create', $scope.faq,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Question + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('faq');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        function LoadCate() {
            apiService.get('api/FAQCategory/GetAll', null, function (result) {
                $scope.faqCategory = result.data;
            }, function () {
                console.log('Tải danh mục FAQ thất bại!');
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.faq.Image = fileUrl;
                })
            }
            finder.popup();
        }

        LoadCate();
    }
})(angular.module('MINHTHUShop.faq'));