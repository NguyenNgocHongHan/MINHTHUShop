/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.news', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('news', {
            url: "/news",
            templateUrl: "/app/components/news/newsView.html",
            /*parent: 'base',*/
            controller: "newsController"
        })
            .state('newsCreate', {
                url: "/newsCreate",
                templateUrl: "/app/components/news/newsCreateView.html",
                /*parent: 'base',*/
                controller: "newsCreateController"
            })
            .state('newsEdit', {
                url: "/newsEdit/:id",
                templateUrl: "/app/components/news/newsEditView.html",
                /*parent: 'base',*/
                controller: "newsEditController"
            })
    }
})();