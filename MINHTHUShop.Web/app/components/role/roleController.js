(function (app) {
    'use strict';

    app.controller('roleController', roleController);

    roleController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function roleController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.loading = true;
        $scope.role = [];
        $scope.index = 0; //đánh số stt trên trang view
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        $scope.DeleteRole = DeleteRole;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("role", function (n, o) {
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

            $ngBootbox.confirm('Bạn có muốn xóa những quyền này không?').then(function () {
                var config = {
                    params: {
                        checkedRole: JSON.stringify(listId)
                    }
                }

                apiService.del('api/Role/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' quyền');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteRole(id) {
            $ngBootbox.confirm('Bạn có muốn xóa quyền này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/Role/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.role, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.role, function (item) {
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

            apiService.get('api/Role/GetAllByPage', config, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            $scope.role = result.data.Item;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPage;
            $scope.totalCount = result.data.TotalCount;
            $scope.loading = false;

        }
        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.keyword = '';
            search();
        }

        $scope.search();
    }
})(angular.module('MINHTHUShop.role'));