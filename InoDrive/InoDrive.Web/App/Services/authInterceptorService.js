﻿"use strict";
app.factory("authInterceptorService", [
    "$q",
    "$injector",
    "localStorageService",
    function (
        $q,
        $injector,
        localStorageService) {

        var authInterceptorServiceFactory = {};

        var $http;
        var $state;
        var authService;
        var customStorageService;

        var request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get("authorizationData");
            if (authData) {
                config.headers.Authorization = "Bearer " + authData.token;
            }

            return config;
        }

        var retryHttpRequest = function (config, deferred) {

            $http = $http || $injector.get("$http");

            $http(config).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });

        }

        var responseError = function (rejection) {

            var deferred = $q.defer();
            if (rejection.status === 401) {

                authService = authService || $injector.get("authService");

                authService.refreshToken().then(function (response) {

                    retryHttpRequest(rejection.config, deferred);

                }, function () {
                    
                    authService.signOut().then(function () {

                        authService.removeAuthorizationData();

                        customStorageService = customStorageService || $injector.get("customStorageService");
                        customStorageService.set("notifyToShow", {
                            message: 'Ваша сессия была завершена!',
                            type: 'info',
                        });

                        $state = $state || $injector.get("$state");
                        $state.go("home", null, { reload: true });

                        deferred.resolve(rejection);

                    }).catch(function () {
                        deferred.reject(rejection);
                    });

                });

            } else {
                deferred.reject(rejection);
            }
            return deferred.promise;
        }

        authInterceptorServiceFactory.request = request;
        authInterceptorServiceFactory.responseError = responseError;

        return authInterceptorServiceFactory;
    }]);