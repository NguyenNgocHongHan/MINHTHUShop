/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.banner', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('banner', {
            url: "/banner",
            parent: 'base',
            templateUrl: "/app/components/banner/bannerView.html",
            controller: "bannerController"
        })
            .state('bannerCreate', {
                url: "/bannerCreate",
                parent: 'base',
                templateUrl: "/app/components/banner/bannerCreateView.html",
                controller: "bannerCreateController"
            })
            .state('bannerEdit', {
                url: "/bannerEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/banner/bannerEditView.html",
                controller: "bannerEditController"
            })
    }
})();