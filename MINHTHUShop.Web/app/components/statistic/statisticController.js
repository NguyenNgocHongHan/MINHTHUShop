(function (app) {
    'use strict';

    app.controller('statisticController', statisticController);

    statisticController.$inject = ['$scope', '$state', '$filter', 'apiService', 'notificationService'];

    function statisticController($scope, $state, $filter, apiService, notificationService) {
        $scope.tabledata = [];
        $scope.labels = [];
        $scope.series = ['Doanh số', 'Lợi nhuận'];

        $scope.chartdata = [];

        $scope.fromDate = '';
        $scope.toDate = '';
        $scope.search = search;

        function search() {
            GetRevenues();
        }

        function GetRevenues() {
            if ($scope.fromDate == '' || $scope.toDate == '') {
                $scope.fromDate = '01/01/2020';
                $scope.toDate = '01/01/2030';
            }
            var config = {
                params: {
                    //mm/dd/yyyy
                    fromDate: $scope.fromDate,
                    toDate: $scope.toDate
                }
            }
            apiService.get('api/Statistic/GetRevenues?fromDate=' + config.params.fromDate + "&toDate=" + config.params.toDate, null
                , function (response) {
                    $scope.tabledata = response.data;
                    $scope.totalRevenues = 0;
                    $scope.totalBenefit = 0;
                    $.each(response.data, function (i, item) {
                        $scope.totalBenefit += item.Benefit;
                        $scope.totalRevenues += item.Revenues;
                    });
                    var labels = [];
                    var chartData = [];
                    var revenues = [];
                    var benefits = [];
                    $.each(response.data, function (i, item) {
                        labels.push($filter('date')(item.Date, 'dd/MM/yyyy'));
                        revenues.push(item.Revenues);
                        benefits.push(item.Benefit);
                    });
                    chartData.push(revenues);
                    chartData.push(benefits);

                    $scope.chartdata = chartData;
                    $scope.labels = labels;
                }, function (response) {
                    notificationService.displayError('Bạn không có quyền truy cập tính năng này!');
                    $state.go('home');
                });
        }

        GetRevenues();
    }
})(angular.module('MINHTHUShop.statistic'));