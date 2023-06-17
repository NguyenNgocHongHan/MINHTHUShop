/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.order', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('order', {
                url: "/order",
                parent: 'base',
                templateUrl: "/app/components/order/orderView.html",
                controller: "orderController"
            })
            .state('orderEdit', {
                url: "/orderEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/order/orderEditView.html",
                controller: "orderEditController"
            })
    }
})();