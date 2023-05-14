/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.faqCategory', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('faqCategory', {
            url: "/faqCategory",
            templateUrl: "/app/components/faqCategory/faqCategoryView.html",
            /*parent: 'base',*/
            controller: "faqCategoryController"
        })
            .state('faqCategoryCreate', {
                url: "/faqCategoryCreate",
                templateUrl: "/app/components/faqCategory/faqCategoryCreateView.html",
                /*parent: 'base',*/
                controller: "faqCategoryCreateController"
            })
            .state('faqCategoryEdit', {
                url: "/faqCategoryEdit/:id",
                templateUrl: "/app/components/faqCategory/faqCategoryEditView.html",
                /*parent: 'base',*/
                controller: "faqCategoryEditController"
            })
    }
})();