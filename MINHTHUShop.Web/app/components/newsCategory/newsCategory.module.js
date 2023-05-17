/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.newsCategory', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('newsCategory', {
            url: "/newsCategory",
            parent: 'base',
            templateUrl: "/app/components/newsCategory/newsCategoryView.html",
            controller: "newsCategoryController"
        })
            .state('newsCategoryCreate', {
                url: "/newsCategoryCreate",
                parent: 'base',
                templateUrl: "/app/components/newsCategory/newsCategoryCreateView.html",
                controller: "newsCategoryCreateController"
            })
            .state('newsCategoryEdit', {
                url: "/newsCategoryEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/newsCategory/newsCategoryEditView.html",
                controller: "newsCategoryEditController"
            })
    }
})();