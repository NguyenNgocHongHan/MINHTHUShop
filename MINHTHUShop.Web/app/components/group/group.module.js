/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.group', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('group', {
            url: "/group",
            parent: 'base',
            templateUrl: "/app/components/group/groupView.html",
            controller: "groupController"
        })
            .state('groupCreate', {
                url: "/groupCreate",
                parent: 'base',
                templateUrl: "/app/components/group/groupCreateView.html",
                controller: "groupCreateController"
            })
            .state('groupEdit', {
                url: "/groupEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/group/groupEditView.html",
                controller: "groupEditController"
            })
    }
})();