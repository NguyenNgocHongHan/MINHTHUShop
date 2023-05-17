/// <reference path="../../../content/admin/lib/angular.js/angular.js" />

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService', 'authService'];

    function apiService($http, notificationService, authService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }

        function get(url, params, success, failure) {
            authService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }

        function post(url, data, success, failure) {
            authService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn cần phải ĐĂNG NHẬP!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        function put(url, data, success, failure) {
            authService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn cần phải ĐĂNG NHẬP!');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }

        function del(url, data, success, failure) {
            authService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn cần phải ĐĂNG NHẬP!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }        
    }
})(angular.module('MINHTHUShop.common'));
