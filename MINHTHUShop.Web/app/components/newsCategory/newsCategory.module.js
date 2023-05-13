/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.newsCategory', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('newsCategory', {
            url: "/newsCategory",
            templateUrl: "/app/components/newsCategory/newsCategoryView.html",
            /*parent: 'base',*/
            controller: "newsCategoryController"
        })
            .state('newsCategoryCreate', {
                url: "/newsCategoryCreate",
                templateUrl: "/app/components/newsCategory/newsCategoryCreateView.html",
                /*parent: 'base',*/
                controller: "newsCategoryCreateController"
            })
            .state('newsCategoryEdit', {
                url: "/newsCategoryEdit/:id",
                templateUrl: "/app/components/newsCategory/newsCategoryEditView.html",
                /*parent: 'base',*/
                controller: "newsCategoryEditController"
            })
    }
})();