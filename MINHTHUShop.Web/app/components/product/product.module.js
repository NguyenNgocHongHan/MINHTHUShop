/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.product', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product', {
            url: "/product",
            parent: 'base',
            templateUrl: "/app/components/product/productView.html",
            controller: "productController"
        })
            .state('productCreate', {
                url: "/productCreate",
                parent: 'base',
                templateUrl: "/app/components/product/productCreateView.html",
                controller: "productCreateController"
            })
            .state('productEdit', {
                url: "/productEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/product/productEditView.html",
                controller: "productEditController"
            })
    }
})();