/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.product', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product', {
            url: "/product",
            templateUrl: "/app/components/product/productView.html",
            /*parent: 'base',*/
            controller: "productController"
        })
            .state('productCreate', {
                url: "/productCreate",
                templateUrl: "/app/components/product/productCreateView.html",
                /*parent: 'base',*/
                controller: "productCreateController"
            })
            .state('productEdit', {
                url: "/productEdit/:id",
                templateUrl: "/app/components/product/productEditView.html",
                /*parent: 'base',*/
                controller: "productEditController"
            })
    }
})();