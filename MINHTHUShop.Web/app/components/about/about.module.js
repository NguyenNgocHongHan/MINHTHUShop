/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.about', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('about', {
            url: "/about",
            parent: 'base',
            templateUrl: "/app/components/about/aboutView.html",
            controller: "aboutController"
        })
            .state('aboutCreate', {
                url: "/aboutCreate",
                parent: 'base',
                templateUrl: "/app/components/about/aboutCreateView.html",
                controller: "aboutCreateController"
            })
            .state('aboutEdit', {
                url: "/aboutEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/about/aboutEditView.html",
                controller: "aboutEditController"
            })
    }
})();