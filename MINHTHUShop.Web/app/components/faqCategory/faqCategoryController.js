(function (app) {
    app.controller('faqCategoryController', faqCategoryController);

    faqCategoryController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function faqCategoryController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.faqCategory = [];
        $scope.GetFAQCategory = GetFAQCategory;

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.DeleteFAQCategory = DeleteFAQCategory;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("faqCategory", function (n, o) {
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
                listId.push(item.FAQCateID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những danh mục FAQ này không?').then(function () {
                var config = {
                    params: {
                        checkedFAQCategory: JSON.stringify(listId)
                    }
                }

                apiService.del('api/FAQCategory/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' danh mục FAQ');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteFAQCategory(id) {
            $ngBootbox.confirm('Bạn có muốn xóa danh mục FAQ này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/FAQCategory/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.faqCategory, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.faqCategory, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetFAQCategory();
        }

        function GetFAQCategory(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/FAQCategory/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.faqCategory = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải danh mục FAQ thất bại!');
            });
        }

        $scope.GetFAQCategory();
    }
})(angular.module('MINHTHUShop.faqCategory'));