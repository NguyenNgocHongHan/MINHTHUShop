(function (app) {
    app.controller('productCategoryController', productCategoryController);

    productCategoryController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function productCategoryController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.productCategory = [];
        $scope.GetProductCategory = GetProductCategory;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteProductCategory = DeleteProductCategory;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("productCategory", function (n, o) {
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
                listId.push(item.CateID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa danh mục sản phẩm này không?').then(function () {
                var config = {
                    params: {
                        checkedProductCategory: JSON.stringify(listId)
                    }
                }

                apiService.del('api/ProductCategory/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' danh mục sản phẩm');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có muốn xóa danh mục sản phẩm này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/ProductCategory/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.productCategory, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.productCategory, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetProductCategory();
        }

        function GetProductCategory(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/ProductCategory/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.productCategory = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải danh mục sản phẩm thất bại!');
            });
        }

        $scope.GetProductCategory();
    }
})(angular.module('MINHTHUShop.productCategory'));