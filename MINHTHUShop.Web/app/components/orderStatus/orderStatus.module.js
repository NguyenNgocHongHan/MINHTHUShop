/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.orderStatus', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('orderStatus', {
            url: "/orderStatus",
            parent: 'base',
            templateUrl: "/app/components/orderStatus/orderStatusView.html",
            controller: "orderStatusController"
        })
            .state('orderStatusCreate', {
                url: "/orderStatusCreate",
                parent: 'base',
                templateUrl: "/app/components/orderStatus/orderStatusCreateView.html",
                controller: "orderStatusCreateController"
            })
            .state('orderStatusEdit', {
                url: "/orderStatusEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/orderStatus/orderStatusEditView.html",
                controller: "orderStatusEditController"
            })
    }
})();