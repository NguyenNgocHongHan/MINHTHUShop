(function (app) {
    'use strict';

    app.controller('userController', userController);

    userController.$inject = ['$scope', '$state', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function userController($scope, $state, $ngBootbox, $filter, apiService, notificationService) {
        $scope.loading = true;
        $scope.user = [];
        $scope.index = 0; //đánh số stt trên trang view
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        $scope.DeleteUser = DeleteUser;

        $scope.isAll = false;

        $scope.$watch("user", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnCheckboxDelete').removeAttr('disabled');
            } else {
                $('#btnCheckboxDelete').attr('disabled', 'disabled');
            }
        }, true);

        function DeleteUser(id) {
            $ngBootbox.confirm('Bạn có muốn xóa người dùng này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/User/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Bạn không có quyền truy cập tính năng này!');
                    $state.go('user');
                })
            });
        }

        function search(page) {
            page = page || 0;

            $scope.loading = true;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/User/GetAllByPage', config, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            $scope.user = result.data.Item;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPage;
            $scope.totalCount = result.data.TotalCount;
            $scope.loading = false;

        }
        function dataLoadFailed() {
            notificationService.displayError('Tải danh sách người dùng thất bại!');
        }

        function clearSearch() {
            $scope.keyword = '';
            search();
        }

        $scope.search();
    }
})(angular.module('MINHTHUShop.user'));