/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.shippingMethod', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('shippingMethod', {
            url: "/shippingMethod",
            parent: 'base',
            templateUrl: "/app/components/shippingMethod/shippingMethodView.html",
            controller: "shippingMethodController"
        })
            .state('shippingMethodCreate', {
                url: "/shippingMethodCreate",
                parent: 'base',
                templateUrl: "/app/components/shippingMethod/shippingMethodCreateView.html",
                controller: "shippingMethodCreateController"
            })
            .state('shippingMethodEdit', {
                url: "/shippingMethodEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/shippingMethod/shippingMethodEditView.html",
                controller: "shippingMethodEditController"
            })
    }
})();