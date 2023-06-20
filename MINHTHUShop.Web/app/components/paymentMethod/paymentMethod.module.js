/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.paymentMethod', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('paymentMethod', {
            url: "/paymentMethod",
            parent: 'base',
            templateUrl: "/app/components/paymentMethod/paymentMethodView.html",
            controller: "paymentMethodController"
        })
            .state('paymentMethodCreate', {
                url: "/paymentMethodCreate",
                parent: 'base',
                templateUrl: "/app/components/paymentMethod/paymentMethodCreateView.html",
                controller: "paymentMethodCreateController"
            })
            .state('paymentMethodEdit', {
                url: "/paymentMethodEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/paymentMethod/paymentMethodEditView.html",
                controller: "paymentMethodEditController"
            })
    }
})();