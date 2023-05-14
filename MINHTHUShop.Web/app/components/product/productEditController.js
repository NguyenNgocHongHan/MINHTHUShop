(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function productEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.product = {}

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.listImg = [];

        $scope.UpdateProduct = UpdateProduct;
        $scope.GetMetaTitle = GetMetaTitle;

        function LoadProductDetail() {
            apiService.get('api/Product/GetById/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                if ($scope.product.ListImg == null) {
                    $scope.listImg = []
                }
                else {
                    $scope.listImg = JSON.parse($scope.product.ListImg); //convert từ 1 chuỗi json thành 1 chuỗi js
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProduct() {
            if ($scope.listImg.length == 0) {
                $scope.product.ListImg = null
            }
            else {
                $scope.product.ListImg = JSON.stringify($scope.listImg) // convert từ 1 chuỗi js thành 1 chuỗi json
            }
            apiService.put('api/Product/Update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function GetMetaTitle() {
            $scope.product.MetaTitle = commonService.getMetaTitle($scope.product.Name);
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
            $scope.listImg.length = 0;
        }

        LoadCate();
        LoadBrand();
        LoadProductDetail();
    }
})(angular.module('MINHTHUShop.product'));