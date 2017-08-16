/// <reference path="C:\Users\User\Documents\Prop24\Prop24\Scripts/angular.js" />

'use strict';

var AuthApp = angular.module('AuthApp', []);

AuthApp.factory('authInterceptorService', ['$q', '$injector', '$window', 'localStorageService', function ($q, $injector, $window, localStorageService) {
    var authInterceptorServiceFactory = {};

    authInterceptorServiceFactory.request = function (config) {
        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'bearer ' + authData.token;
        }
        return config;
    }

    authInterceptorServiceFactory.responseError = function (rejection) {
        if (rejection.status === 401) {
            var authService = $injector.get('authService');
            var authData = localStorageService.get('authorizationData');
            //authService.logOut();
        }
        return $q.reject(rejection);
    };
    return authInterceptorServiceFactory;
}]);

AuthApp.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorage) {
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        Email: "" 
    };

    authServiceFactory.login = function (loginData) {
        var data = "grant_type=passcode&email=" + loginData.Email + "&passcode=" + loginData.Password;

        var deferred = $q.defer();

        $http.post('/token', data, {
            header: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).success(function (response) {
            localStorageService.set('authorizationData', { token: response.access_token, Email: response.Email });

            _authentication.isAuth = true;
            _authentication.Email = loginData.Email;

            deferred.resolve(response);
        }).error(function (err) {
            //_logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    };

    authServiceFactory.logOut = function () {
        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.Email = "";
    };
    return authService;
}])