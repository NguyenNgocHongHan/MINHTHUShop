/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.role', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('role', {
            url: "/role",
            parent: 'base',
            templateUrl: "/app/components/role/roleView.html",
            controller: "roleController"
        })
            .state('roleCreate', {
                url: "/roleCreate",
                parent: 'base',
                templateUrl: "/app/components/role/roleCreateView.html",
                controller: "roleCreateController"
            })
            .state('roleEdit', {
                url: "/roleEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/role/roleEditView.html",
                controller: "roleEditController"
            })
    }
})();