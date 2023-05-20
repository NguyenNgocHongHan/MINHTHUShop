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

        $scope.listImg = [];

        $scope.CreateProduct = CreateProduct;
        $scope.GetMetaTitle = GetMetaTitle;

        function GetMetaTitle() {
            $scope.product.MetaTitle = commonService.getMetaTitle($scope.product.Name);
        }

        function CreateProduct() {
            $scope.product.ListImg = JSON.stringify($scope.listImg) //convert chuỗi từ js thành json
            apiService.post('api/Product/Create', $scope.product,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
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
                console.log('Tải danh mục sản phẩm thất bại!');
            });
        }

        function LoadBrand() {
            apiService.get('api/Brand/GetAll', null, function (result) {
                $scope.brand = result.data;
            }, function () {
                console.log('Tải thương hiệu thất bại!');
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () { //dùng để bắt ảnh ngay mà không cần phải đợi lâu để load ảnh
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.listImg.push(fileUrl);
                })
            }
            finder.popup();
        }

        $scope.DeleteImage = function () {
            $scope.product.Image = null;
        }

        $scope.DeleteMoreImage = function () {
            $scope.listImg = [];
        }

        LoadCate();
        LoadBrand();
    }
})(angular.module('MINHTHUShop.product'));