(function (app) {
    app.controller('newsCategoryController', newsCategoryController);

    newsCategoryController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function newsCategoryController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.newsCategory = [];
        $scope.parentCategory = [];

        $scope.GetNewsCategory = GetNewsCategory;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteNewsCategory = DeleteNewsCategory;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("newsCategory", function (n, o) {
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
                listId.push(item.NewsCateID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những danh mục tin tức này không?').then(function () {
                var config = {
                    params: {
                        checkedNewsCategory: JSON.stringify(listId)
                    }
                }

                apiService.del('api/NewsCategory/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' danh mục tin tức');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteNewsCategory(id) {
            $ngBootbox.confirm('Bạn có muốn xóa danh mục tin tức này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/NewsCategory/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.newsCategory, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.newsCategory, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetNewsCategory();
        }

        function GetNewsCategory(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/NewsCategory/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.newsCategory = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải danh mục tin tức thất bại!');
            });
        }

        function LoadParentCategory() {
            apiService.get('api/NewsCategory/GetAll', null, function (result) {
                /*console.log(result);*/
                $scope.parentCategory = result.data;
                /*$scope.parentCategory = commonService.getTree(result.data, "CateID", "ParentID");*/
                /*$scope.parentCategories.forEach(function (item) {
                    recur(item, 0, $scope.flatFolders);
                });*/
            }, function () {
                console.log('Không thể lấy ra danh sách thư mục cha!');
            });
        }

        $scope.GetNewsCategory();

        LoadParentCategory();
    }
})(angular.module('MINHTHUShop.newsCategory'));