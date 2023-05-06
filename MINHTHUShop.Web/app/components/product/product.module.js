/// <reference path="../../../content/admin/lib/angular.js/angular.js" />
(function () {
    angular.module('MINHTHUShop.product', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product', {
                url: "/product",
                /*parent: 'base',*/
                templateUrl: "/app/components/product/productView.html",
                controller: "productController"
            }).state('product_create', {
                url: "/product_create",
                /*parent: 'base',*/
                templateUrl: "/app/components/product/productCreateView.html",
                controller: "productCreateController"
            })
            /*.state('product_import', {
                url: "/product_import",
                parent: 'base',
                templateUrl: "/app/components/product/productImportView.html",
                controller: "productImportController"
            })
            .state('product_edit', {
                url: "/product_edit/:id",
                parent: 'base',
                templateUrl: "/app/components/product/productEditView.html",
                controller: "productEditController"
            })*/;
    }
})();