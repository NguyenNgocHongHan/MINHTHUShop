(function (app) {
    app.controller('aboutCreateController', aboutCreateController);

    aboutCreateController.$inject = ['$scope', '$state', 'apiService', 'notificationService'];

    function aboutCreateController($scope, $state, apiService, notificationService) {
        $scope.about = {
            CreateDate: new Date(),
            Status: true,
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.CreateAbout = CreateAbout;

        function CreateAbout() {
            apiService.post('api/About/Create', $scope.about,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    //điều hướng đến trang mới
                    $state.go('about');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công!');
                });
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
})(angular.module('MINHTHUShop.about'));