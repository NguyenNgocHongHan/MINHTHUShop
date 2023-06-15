/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.user', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('user', {
            url: "/user",
            parent: 'base',
            templateUrl: "/app/components/user/userView.html",
            controller: "userController"
        })
            .state('userCreate', {
                url: "/userCreate",
                parent: 'base',
                templateUrl: "/app/components/user/userCreateView.html",
                controller: "userCreateController"
            })
            .state('userEdit', {
                url: "/userEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/user/userEditView.html",
                controller: "userEditController"
            })
    }
})();