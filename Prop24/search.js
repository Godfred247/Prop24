/// <reference path="C:\Users\User\Documents\Prop24\Prop24\Scripts/angular.js" />

var searchProp = angular.module("searchProp", []);

searchProp.controller('SearchCtrl', ['$scope', '$http', function (Scope, $http) {
    $scope.urlBase = " ";

    $scope.search = function () {
        $http.post($scope.url, { "data": $scope.keywords }).then(function (data, suburb) {
            $scope.suburb = suburb;
            $scope.data = data;
            $scope.result = data;
        }).error(function (suburb, status) {
            $scope.data = data;
            $scope.status = status;
        })
    }
}]);