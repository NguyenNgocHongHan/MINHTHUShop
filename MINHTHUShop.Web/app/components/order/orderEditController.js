(function (app) {
    app.controller('orderEditController', orderEditController);

    orderEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function orderEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.order = {}
        $scope.orderDetail = [];
        $scope.product = [];
        $scope.shippingMethod = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.LoadProduct = LoadProduct;
        $scope.UpdateOrder = UpdateOrder;

        function LoadOrderDetail() {
            apiService.get('api/Order/GetById/' + $stateParams.id, null, function (result) {
                $scope.order = result.data;

                $scope.shipCost = 0;
                apiService.get('api/ShippingMethod/GetAll', null, function (result) {
                    $scope.shippingMethod = result.data;
                    $.each($scope.shippingMethod, function (i, s) {
                        if (s.ShippingMethodID == $scope.order.ShippingMethodID) {
                            $scope.shipCost = s.Cost;
                        }
                    });
                }, function () {
                    console.log('Tải phương thức vận chuyển thất bại!');
                });

                $scope.totalOrder = 0;

                apiService.get('api/OrderDetail/GetAll', null, function (result) {
                    $scope.orderDetail = result.data;
                    $.each($scope.orderDetail, function (i, od) {
                        if ($scope.order.OrderID == od.OrderID) {
                            apiService.get('api/Product/GetAll', null, function (result) {
                                $scope.product = result.data;
                                $.each($scope.product, function (i, p) {
                                    if (od.ProductID == p.ProductID) {
                                        $scope.totalOrder += (od.Quantity * p.PromotionPrice);
                                    }
                                });
                            }, function () {
                                console.log('Tải sản phẩm thất bại!');
                            });
                        }
                    });
                }, function (error) {
                    notificationService.displayError('Tải chi tiết đơn hàng thất bại!');
                });
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function LoadOrderDetailDetail() {
            apiService.get('api/OrderDetail/GetAll', null, function (result) {
                $scope.orderDetail = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateOrder() {
            apiService.put('api/Order/Update', $scope.order,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                    $state.go('order');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function LoadShippingMethod() {
            apiService.get('api/ShippingMethod/GetAll', null, function (result) {
                $scope.shippingMethod = result.data;
            }, function () {
                console.log('Tải phương thức vận chuyển thất bại!');
            });
        }

        function LoadPaymentMethod() {
            apiService.get('api/PaymentMethod/GetAll', null, function (result) {
                $scope.paymentmethod = result.data;
            }, function () {
                console.log('Tải phương thức thanh toán thất bại!');
            });
        }

        function LoadStatus() {
            apiService.get('api/OrderStatus/GetAll', null, function (result) {
                $scope.orderstatus = result.data;
            }, function () {
                console.log('Tải trạng thái đơn hàng thất bại!');
            });
        }

        function LoadProduct() {
            apiService.get('api/Product/GetAll', null, function (result) {
                $scope.product = result.data;
            }, function () {
                console.log('Tải sản phẩm thất bại!');
            });
        }

        LoadPaymentMethod();
        LoadStatus();
        LoadOrderDetailDetail();
        LoadProduct();
        LoadShippingMethod();
        LoadOrderDetail();
    }
})(angular.module('MINHTHUShop.order'));