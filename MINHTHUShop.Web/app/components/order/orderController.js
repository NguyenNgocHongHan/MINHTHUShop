(function (app) {
    app.controller('orderController', orderController);

    orderController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function orderController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.order = [];
        $scope.users = [];
        $scope.orderstatus = [];

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.GetOrder = GetOrder;
        $scope.DeleteOrder = DeleteOrder;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("order", function (n, o) {
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
                listId.push(item.OrderID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những đơn hàng này không?').then(function () {
                var config = {
                    params: {
                        checkedOrder: JSON.stringify(listId)
                    }
                }

                apiService.del('api/Order/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' đơn hàng');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteOrder(id) {
            $ngBootbox.confirm('Bạn có muốn xóa đơn hàng này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/Order/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.order, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.order, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetOrder();
        }

        function GetOrder(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/Order/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.order = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải đơn hàng thất bại!');
            });
        }

        function LoadUser() {
            apiService.get('api/User/GetAll', null, function (result) {
                $scope.users = result.data;
            }, function () {
                console.log('Tải danh mục người dùng thất bại!');
            });
        }

        function LoadStatus() {
            apiService.get('api/OrderStatus/GetAll', null, function (result) {
                $scope.orderstatus = result.data;
            }, function () {
                console.log('Tải trạng thái đơn hàng thất bại!');
            });
        }

        $scope.GetOrder();
        LoadUser();
        LoadStatus();
    }
})(angular.module('MINHTHUShop.order'));