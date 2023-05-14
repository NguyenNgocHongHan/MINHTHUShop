/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.faq', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('faq', {
            url: "/faq",
            templateUrl: "/app/components/faq/faqView.html",
            /*parent: 'base',*/
            controller: "faqController"
        })
            .state('faqCreate', {
                url: "/faqCreate",
                templateUrl: "/app/components/faq/faqCreateView.html",
                /*parent: 'base',*/
                controller: "faqCreateController"
            })
            .state('faqEdit', {
                url: "/faqEdit/:id",
                templateUrl: "/app/components/faq/faqEditView.html",
                /*parent: 'base',*/
                controller: "faqEditController"
            })
    }
})();