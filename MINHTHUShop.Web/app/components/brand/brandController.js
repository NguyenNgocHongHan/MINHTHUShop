(function (app) {
    app.controller('brandController', brandController);

    brandController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function brandController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.brand = [];
        $scope.GetBrand = GetBrand;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteBrand = DeleteBrand;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("brand", function (n, o) {
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
                listId.push(item.BrandID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những thương hiệu / hãng sản xuất này không?').then(function () {
                var config = {
                    params: {
                        checkedBrand: JSON.stringify(listId)
                    }
                }

                apiService.del('api/Brand/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' thương hiệu / hãng sản xuất');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteBrand(id) {
            $ngBootbox.confirm('Bạn có muốn xóa thương hiệu / hãng sản xuất này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/Brand/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.brand, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.brand, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetBrand();
        }

        function GetBrand(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/Brand/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.brand = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải thương hiệu / hãng sản xuất thất bại!');
            });
        }

        $scope.GetBrand();
    }
})(angular.module('MINHTHUShop.brand'));