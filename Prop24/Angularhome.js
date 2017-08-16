var app = angular.module('homeapp', []);

app.controller('LoginController', ['$scope', 'loginService', function ($scope, loginService) {
    $scope.btntext = "Login";
    $scope.login = function () {
        $scope.btntext = "Please Wait...";
        loginService.getLogin($scope.email, $scope.password).then(function (response) {
            if (response.data == null)
            {
                alert("Error, Try Again");
                $scope.password = undefined;
            }
            else
            {
                $scope.logged = response.data;
                alert("Welcome " + response.data.email + ". Press 'OK' to proceed");
                window.location.href = "../userIndex.html";
            }
        })
    }
}]);

app.factory('loginService', function ($http) {
    loginService = {};
    var urlBase = "http://localhost:15446/Api/login"

    loginService.getLogin = function (email, password) {
        return $http.get(urlBase + "?email=" + email + "&password=" + password);
    }
    return loginService;
})