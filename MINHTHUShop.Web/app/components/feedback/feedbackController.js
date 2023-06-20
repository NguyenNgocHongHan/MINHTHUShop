(function (app) {
    app.controller('feedbackController', feedbackController);

    feedbackController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function feedbackController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.feedback = [];

        $scope.index = 0;

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 10;

        $scope.keyword = '';
        $scope.search = search;

        $scope.GetFeedback = GetFeedback;
        $scope.DeleteFeedback = DeleteFeedback;
        $scope.DeleteMultiple = DeleteMultiple;
        $scope.SelectAll = SelectAll;

        $scope.isAll = false;

        $scope.$watch("feedback", function (n, o) {
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
                listId.push(item.FeedbackID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa những Feedback này không?').then(function () {
                var config = {
                    params: {
                        checkedFeedback: JSON.stringify(listId)
                    }
                }

                apiService.del('api/Feedback/DeleteMulti', config, function (result) {
                    notificationService.displaySuccess('Đã xóa ' + result.data + ' Feedback');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function DeleteFeedback(id) {
            $ngBootbox.confirm('Bạn có muốn xóa Feedback này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/Feedback/Delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.feedback, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.feedback, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            GetFeedback();
        }

        function GetFeedback(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }

            apiService.get('api/Feedback/GetAllByPage', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả!');
                }
                $scope.feedback = result.data.Item;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Tải Feedback thất bại!');
            });
        }

        $scope.GetFeedback();
    }
})(angular.module('MINHTHUShop.feedback'));