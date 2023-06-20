(function (app) {
    app.controller('shippingMethodController', shippingMethodController);

    shippingMethodController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function shippingMethodController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.shippingMethod = [];
        $scope.GetShippingMethod = GetShippingMethod;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteShippingMethod = DeleteShippingMethod;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("shippingMethod", function (n, o) {
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
                listId.push(item.ShippingMethodID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những phương thức vận chuyển này không?').then(function () {
                var config = {
                    params: {
                        checkedShippingMethod: JSON.stringify(listId)
                    }
                }

                apiService.del('api/ShippingMethod/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' phương thức vận chuyển');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteShippingMethod(id) {
            $ngBootbox.confirm('Bạn có muốn xóa phương thức vận chuyển này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/ShippingMethod/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.shippingMethod, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.shippingMethod, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetShippingMethod();
        }

        function GetShippingMethod(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/ShippingMethod/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.shippingMethod = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải phương thức vận chuyển thất bại!');
            });
        }

        $scope.GetShippingMethod();
    }
})(angular.module('MINHTHUShop.shippingMethod'));