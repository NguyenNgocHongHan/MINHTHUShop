(function (app) {
    app.controller('newsController', newsController);

    newsController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function newsController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.news = [];

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.GetNews = GetNews;
        $scope.DeleteNews = DeleteNews;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("news", function (n, o) {
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
                listId.push(item.NewsID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những sản phẩm này không?').then(function () {
                var config = {
                    params: {
                        checkedProduct: JSON.stringify(listId)
                    }
                }

                apiService.del('api/Product/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' sản phẩm');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteNews(id) {
            $ngBootbox.confirm('Bạn có muốn xóa tin tức này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/News/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.news, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.news, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetNews();
        }

        function GetNews(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/News/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.news = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải sản phẩm thất bại!');
            });
        }

        function LoadCate() {
            apiService.get('api/NewsCategory/GetAll', null, function (result) {
                $scope.newsCategory = result.data;
            }, function () {
                console.log('Tải sản danh mục tin tức thất bại!');
            });
        }

        LoadCate();

        $scope.GetNews();
    }
})(angular.module('MINHTHUShop.news'));