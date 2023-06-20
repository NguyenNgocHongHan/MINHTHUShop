/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function () {
    angular.module('MINHTHUShop.feedback', ['MINHTHUShop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('feedback', {
            url: "/feedback",
            parent: 'base',
            templateUrl: "/app/components/feedback/feedbackView.html",
            controller: "feedbackController"
        })
            .state('feedbackEdit', {
                url: "/feedbackEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/feedback/feedbackEditView.html",
                controller: "feedbackEditController"
            })
    }
})();