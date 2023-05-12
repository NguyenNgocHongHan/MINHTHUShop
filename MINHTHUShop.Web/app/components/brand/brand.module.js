/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.brand', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('brand', {
            url: "/brand",
            templateUrl: "/app/components/brand/brandView.html",
            /*parent: 'base',*/
            controller: "brandController"
        })
            .state('brandCreate', {
                url: "/brandCreate",
                templateUrl: "/app/components/brand/brandCreateView.html",
                /*parent: 'base',*/
                controller: "brandCreateController"
            })
            .state('brandEdit', {
                url: "/brandEdit/:id",
                templateUrl: "/app/components/brand/brandEditView.html",
                /*parent: 'base',*/
                controller: "brandEditController"
            })
    }
})();