/// <reference path="C:\Users\User\Documents\Prop24\Prop24\Scripts/angular.js" />

var app = angular.Module('Myapp', ['ngRoute', 'UserService']);

app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
        when('/Register', {
            templateUrl: 'register.html',
            controller: 'UserController'
        }),
        when('/Home', {
            templateUrl: 'home.html',
            controller: 'HomeController'
        }),
        otherwise({
            redirectTo: '/Home'
        });
    }
]);
app.controller("UserController", function ($scope, UserApi) {
    $scope.AddUser = function () {
        var usrToAdd = {
            'Email': $scope.email,
            'Password': $scope.password
        };
        UserApi.AddUser(usrToAdd).success(function (response) {
            alert("User added!");
            $scope.Email = undefined;
            $scope.Password = undefined;
        })
            ,function (response) {
            alert("Error in Adding");
        };
    }
});
app.controller("HomeController", function ($scope, UserApi) {
    //$scope.message = "Home View";

    UserService.factory("UserApi", function ($http) {
        var urlBase = "http://localhost:15446/api/User";
        var UserApi = {};
        UserApi.AddUser = function () {
            return $http.get(urlBase + '/User');
        }
    })
});
