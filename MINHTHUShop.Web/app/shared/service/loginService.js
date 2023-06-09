﻿(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authService', 'authData', 'apiService',
        function ($http, $q, authService, authData, apiService) {
            var userInfo;
            var deferred;

            this.Login = function (userName, password) {
                deferred = $q.defer();
                var data = "grant_type=password&username=" + userName + "&password=" + password;
                $http.post('/oauth/token', data, {
                    headers:
                        { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).then(function (response) {
                    userInfo = {
                        accessToken: response.data.access_token,
                        userName: userName
                    };
                    authService.setTokenInfo(userInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = userName;
                    authData.authenticationData.accessToken = userInfo.accessToken;

                    deferred.resolve(null);
                }, function (err, status) {
                    authData.authenticationData.IsAuthenticated = false;
                    authData.authenticationData.userName = "";
                    deferred.resolve(err);
                })
                return deferred.promise;
            }

            this.Logout = function () {
                /*authService.removeToken();
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";*/

                apiService.post('/api/Account/Logout', null, function (response) {
                    authService.removeToken();
                    authData.authenticationData.IsAuthenticated = false;
                    authData.authenticationData.userName = "";
                    authData.authenticationData.accessToken = "";

                }, null);
            }
        }]);
})(angular.module('MINHTHUShop.common'));