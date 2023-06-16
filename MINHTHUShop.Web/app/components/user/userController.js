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
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

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

        function DeleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.Id);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những người dùng này không?').then(function () {
                var config = {
                    params: {
                        checkedUser: JSON.stringify(listId)
                    }
                }

                apiService.del('api/User/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' người dùng');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

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
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.user, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.user, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
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
            notificationService.displayError('Bạn không có quyền truy cập tính năng này!');
            $state.go('home');
        }

        function clearSearch() {
            $scope.keyword = '';
            search();
        }

        $scope.search();
    }
})(angular.module('MINHTHUShop.user'));