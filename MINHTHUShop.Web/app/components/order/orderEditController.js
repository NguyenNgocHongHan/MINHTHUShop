(function (app) {
    app.controller('orderEditController', orderEditController);

    orderEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function orderEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.order = {}
        $scope.orderDetail = {}
        $scope.product = [];
        $scope.productCategory = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.GetProduct = GetProduct;

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.UpdateOrder = UpdateOrder;

        function LoadOrderDetail() {
            apiService.get('api/Order/GetById/' + $stateParams.id, null, function (result) {
                $scope.order = result.data;
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
                $scope.shippingmethod = result.data;
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

        $scope.GetProduct();
        LoadCate();

        LoadShippingMethod();
        LoadPaymentMethod();
        LoadStatus();
        LoadOrderDetail();
        LoadOrderDetailDetail();
    }
})(angular.module('MINHTHUShop.order'));