(function (app) {
    app.controller('orderStatusController', orderStatusController);

    orderStatusController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function orderStatusController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.orderStatus = [];
        $scope.GetOrderStatus = GetOrderStatus;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteOrderStatus = DeleteOrderStatus;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("orderStatus", function (n, o) {
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
                listId.push(item.OrderStatusID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những trạng thái này không?').then(function () {
                var config = {
                    params: {
                        checkedOrderStatus: JSON.stringify(listId)
                    }
                }

                apiService.del('api/OrderStatus/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' trạng thái đơn hàng');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteOrderStatus(id) {
            $ngBootbox.confirm('Bạn có muốn xóa trạng thái này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/OrderStatus/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.orderStatus, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.orderStatus, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetOrderStatus();
        }

        function GetOrderStatus(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/OrderStatus/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.orderStatus = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải trạng thái thất bại!');
            });
        }

        $scope.GetOrderStatus();
    }
})(angular.module('MINHTHUShop.orderStatus'));