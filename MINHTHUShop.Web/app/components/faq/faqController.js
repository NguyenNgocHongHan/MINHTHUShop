(function (app) {
    app.controller('faqController', faqController);

    faqController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function faqController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.faq = [];

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.GetFAQ = GetFAQ;
        $scope.DeleteFAQ = DeleteFAQ;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("faq", function (n, o) {
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
                listId.push(item.FAQID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những FAQ này không?').then(function () {
                var config = {
                    params: {
                        checkedFAQ: JSON.stringify(listId)
                    }
                }

                apiService.del('api/FAQ/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' FAQ');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteFAQ(id) {
            $ngBootbox.confirm('Bạn có muốn xóa FAQ này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/FAQ/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.faq, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.faq, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetFAQ();
        }

        function GetFAQ(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/FAQ/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.faq = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải FAQ thất bại!');
            });
        }

        function LoadCate() {
            apiService.get('api/FAQCategory/GetAll', null, function (result) {
                $scope.faqCategory = result.data;
            }, function () {
                console.log('Tải danh mục FAQ thất bại!');
            });
        }

        LoadCate();

        $scope.GetFAQ();
    }
})(angular.module('MINHTHUShop.faq'));