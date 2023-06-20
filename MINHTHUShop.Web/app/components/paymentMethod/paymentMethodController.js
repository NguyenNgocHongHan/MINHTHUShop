(function (app) {
    app.controller('paymentMethodController', paymentMethodController);

    paymentMethodController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function paymentMethodController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.paymentMethod = [];
        $scope.GetPaymentMethod = GetPaymentMethod;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeletePaymentMethod = DeletePaymentMethod;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("paymentMethod", function (n, o) {
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
                listId.push(item.PaymentMethodID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những phương thức thanh toán này không?').then(function () {
                var config = {
                    params: {
                        checkedPaymentMethod: JSON.stringify(listId)
                    }
                }

                apiService.del('api/PaymentMethod/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' phương thức thanh toán');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeletePaymentMethod(id) {
            $ngBootbox.confirm('Bạn có muốn xóa phương thức thanh toán này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/PaymentMethod/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.paymentMethod, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.paymentMethod, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetPaymentMethod();
        }

        function GetPaymentMethod(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/PaymentMethod/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.paymentMethod = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải phương thức thanh toán thất bại!');
            });
        }

        $scope.GetPaymentMethod();
    }
})(angular.module('MINHTHUShop.paymentMethod'));