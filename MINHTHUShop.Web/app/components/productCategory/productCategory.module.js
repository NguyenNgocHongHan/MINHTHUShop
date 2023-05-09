/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.productCategory', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productCategory', {
            url: "/productCategory",
            templateUrl: "/app/components/productCategory/productCategoryView.html",
            /*parent: 'base',*/
            controller: "productCategoryController"
        })
            .state('productCategoryCreate', {
                url: "/productCategoryCreate",
                templateUrl: "/app/components/productCategory/productCategoryCreateView.html",
                /*parent: 'base',*/
                controller: "productCategoryCreateController"
            })
            /*.state('editProductCategory', {
                url: "/editProductCategory",
                templateUrl: "/app/components/productCategory/productCategoryEditView.html",
                parent: 'base',
                controller: "productCategoryEditControler"
            })*/
    }
})();