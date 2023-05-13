(function (app) {
    app.controller('productController', productController);

    productController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function productController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.product = [];

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.GetProduct = GetProduct;
        $scope.DeleteProduct = DeleteProduct;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("product", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnCheckboxDelete').removeAttr('disabled');
            } else {
                $('#btnCheckboxDelete').attr('disabled', 'disabled');
            }
        }, true);

        function DeleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ProductID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những sản phẩm này không?').then(function () {
                var config = {
                    params: {
                        checkedProduct: JSON.stringify(listId)
                    }
                }

                apiService.del('api/Product/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' sản phẩm');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteProduct(id) {
            $ngBootbox.confirm('Bạn có muốn xóa sản phẩm này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/Product/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.product, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.product, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetProduct();
        }

        function GetProduct(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/Product/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.product = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải sản phẩm thất bại!');
            });
        }

        function LoadCate() {
            apiService.get('api/ProductCategory/GetAll', null, function (result) {
                $scope.productCategory = result.data;
            }, function () {
                console.log('Tải sản danh mục sản phẩm thất bại!');
            });
        }

        LoadCate();

        $scope.GetProduct();
    }
})(angular.module('MINHTHUShop.product'));