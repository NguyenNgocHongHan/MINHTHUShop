/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.faqCategory', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('faqCategory', {
            url: "/faqCategory",
            parent: 'base',
            templateUrl: "/app/components/faqCategory/faqCategoryView.html",
            controller: "faqCategoryController"
        })
            .state('faqCategoryCreate', {
                url: "/faqCategoryCreate",
                parent: 'base',
                templateUrl: "/app/components/faqCategory/faqCategoryCreateView.html",
                controller: "faqCategoryCreateController"
            })
            .state('faqCategoryEdit', {
                url: "/faqCategoryEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/faqCategory/faqCategoryEditView.html",
                controller: "faqCategoryEditController"
            })
    }
})();