﻿/// <reference path="../content/admin/lib/angular.js/angular.js" />
(function () {
    angular.module('MINHTHUShop',
        [
            'MINHTHUShop.productCategory',
            'MINHTHUShop.faqCategory',
            'MINHTHUShop.product',
            'MINHTHUShop.faq',
            'MINHTHUShop.brand',
            'MINHTHUShop.webpage',
            'MINHTHUShop.banner',
            'MINHTHUShop.feedback',
            'MINHTHUShop.orderStatus',
            'MINHTHUShop.paymentMethod',
            'MINHTHUShop.shippingMethod',
            'MINHTHUShop.group',
            'MINHTHUShop.role',
            'MINHTHUShop.user',
            'MINHTHUShop.order',
            'MINHTHUShop.statistic',
            'MINHTHUShop.common'])
        .config(config)
        .config(configAuth);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/view/baseView.html',
                abstract: true
            }).state('login', {
                url: "/login",
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }

    function configAuth($httpProvider) {
        //kiểm tra request tới server
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {
                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();