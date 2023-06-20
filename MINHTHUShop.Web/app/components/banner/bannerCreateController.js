(function (app) {
    app.controller('bannerCreateController', bannerCreateController);

    bannerCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService'];

    function bannerCreateController($scope, $state, apiService, notificationService) {
        $scope.banner = {
            CreateDate: new Date(),
            Status: true,
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.CreateBanner = CreateBanner;

        function CreateBanner() {
            apiService.post('api/Banner/Create', $scope.banner,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('banner');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.banner.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.DeleteImage = function () {
            $scope.banner.Image = null;
        }


        /*        $scope.flatFolders = [];
       
       
       
               function times(n, str) {
                   var result = '';
                   for (var i = 0; i < n; i++) {
                       result += str;
                   }
                   return result;
               };
               function recur(item, level, arr) {
                   arr.push({
                       Name: times(level, '–') + ' ' + item.Name,
                       ID: item.ID,
                       Level: level,
                       Indent: times(level, '–')
                   });
                   if (item.children) {
                       item.children.forEach(function (item) {
                           recur(item, level + 1, arr);
                       });
                   }
               };*/
    }
})(angular.module('MINHTHUShop.banner'));