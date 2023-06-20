/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.statistic', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('statistic', {
            url: "/statistic",
            parent: 'base',
            templateUrl: "/app/components/statistic/statisticView.html",
            controller: "statisticController"
        })
    }
})();