/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.brand', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('brand', {
            url: "/brand",
            parent: 'base',
            templateUrl: "/app/components/brand/brandView.html",
            controller: "brandController"
        })
            .state('brandCreate', {
                url: "/brandCreate",
                parent: 'base',
                templateUrl: "/app/components/brand/brandCreateView.html",
                controller: "brandCreateController"
            })
            .state('brandEdit', {
                url: "/brandEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/brand/brandEditView.html",
                controller: "brandEditController"
            })
    }
})();