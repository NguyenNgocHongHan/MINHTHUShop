/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.webpage', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('webpage', {
            url: "/webpage",
            parent: 'base',
            templateUrl: "/app/components/webpage/webpageView.html",
            controller: "webpageController"
        })
            .state('webpageCreate', {
                url: "/webpageCreate",
                parent: 'base',
                templateUrl: "/app/components/webpage/webpageCreateView.html",
                controller: "webpageCreateController"
            })
            .state('webpageEdit', {
                url: "/webpageEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/webpage/webpageEditView.html",
                controller: "webpageEditController"
            })
    }
})();