(function (app) {
    app.controller('aboutController', aboutController);

    aboutController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function aboutController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.about = [];
        $scope.GetAbout = GetAbout;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteAbout = DeleteAbout;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("about", function (n, o) {
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
                listId.push(item.AboutID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những thông tin liên hệ này không?').then(function () {
                var config = {
                    params: {
                        checkedAbout: JSON.stringify(listId)
                    }
                }

                apiService.del('api/About/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' thông tin liên hệ');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteAbout(id) {
            $ngBootbox.confirm('Bạn có muốn xóa thông tin liên hệ này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/About/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.about, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.about, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetAbout();
        }

        function GetAbout(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/About/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.about = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải thông tin liên hệ thất bại!');
            });
        }

        $scope.GetAbout();
    }
})(angular.module('MINHTHUShop.about'));