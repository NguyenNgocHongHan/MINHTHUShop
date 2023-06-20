/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.productCategory', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productCategory', {
            url: "/productCategory",
            parent: 'base',
            templateUrl: "/app/components/productCategory/productCategoryView.html",
            controller: "productCategoryController"
        })
            .state('productCategoryCreate', {
                url: "/productCategoryCreate",
                parent: 'base',
                templateUrl: "/app/components/productCategory/productCategoryCreateView.html",
                controller: "productCategoryCreateController"
            })
            .state('productCategoryEdit', {
                url: "/productCategoryEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/productCategory/productCategoryEditView.html",
                controller: "productCategoryEditController"
            })
    }
})();