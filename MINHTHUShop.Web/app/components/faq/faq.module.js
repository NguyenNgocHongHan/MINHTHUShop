/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.faq', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('faq', {
            url: "/faq",
            parent: 'base',
            templateUrl: "/app/components/faq/faqView.html",
            controller: "faqController"
        })
            .state('faqCreate', {
                url: "/faqCreate",
                parent: 'base',
                templateUrl: "/app/components/faq/faqCreateView.html",
                controller: "faqCreateController"
            })
            .state('faqEdit', {
                url: "/faqEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/faq/faqEditView.html",
                controller: "faqEditController"
            })
    }
})();