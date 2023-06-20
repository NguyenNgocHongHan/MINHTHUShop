(function (app) {
    app.controller('bannerController', bannerController);

    bannerController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function bannerController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.banner = [];
        $scope.GetBanner = GetBanner;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteBanner = DeleteBanner;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("banner", function (n, o) {
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
                listId.push(item.BannerID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những banner này không?').then(function () {
                var config = {
                    params: {
                        checkedBanner: JSON.stringify(listId)
                    }
                }

                apiService.del('api/Banner/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' banner');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteBanner(id) {
            $ngBootbox.confirm('Bạn có muốn xóa banner này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/Banner/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.banner, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.banner, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetBanner();
        }

        function GetBanner(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/Banner/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.banner = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải banner thất bại!');
            });
        }

        $scope.GetBanner();
    }
})(angular.module('MINHTHUShop.banner'));