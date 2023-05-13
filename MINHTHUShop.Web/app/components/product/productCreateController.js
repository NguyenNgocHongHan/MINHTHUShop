(function (app) {
    app.controller('productCreateController', productCreateController);

    productCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function productCreateController($scope, $state, apiService, notificationService, commonService) {
        $scope.product = {
            Price: 0,
            CreateDate: new Date(),
            Status: true,
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.moreImages = [];

        $scope.CreateProduct = CreateProduct;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.product.MetaTitle = commonService.getMetaTitle($scope.product.Name);
        }

        function CreateProduct() {
            apiService.post('api/Product/Create', $scope.product,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' vào danh mục sản phẩm');
                    //điều hướng đến trang mới
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        function LoadCate() {
            apiService.get('api/ProductCategory/GetAll', null, function (result) {
                $scope.productCategory = result.data;
            }, function () {
                console.log('Tải sản danh mục sản phẩm thất bại!');
            });
        }

        function LoadBrand() {
            apiService.get('api/Brand/GetAll', null, function (result) {
                $scope.brand = result.data;
            }, function () {
                console.log('Tải sản thương hiệu thất bại!');
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })

            }
            finder.popup();
        }

        LoadCate();
        LoadBrand();
    }
})(angular.module('MINHTHUShop.product'));