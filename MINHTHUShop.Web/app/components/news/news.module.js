/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.news', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('news', {
            url: "/news",
            parent: 'base',
            templateUrl: "/app/components/news/newsView.html",
            controller: "newsController"
        })
            .state('newsCreate', {
                url: "/newsCreate",
                parent: 'base',
                templateUrl: "/app/components/news/newsCreateView.html",
                controller: "newsCreateController"
            })
            .state('newsEdit', {
                url: "/newsEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/news/newsEditView.html",
                controller: "newsEditController"
            })
    }
})();