/// <reference path="C:\Users\User\Documents\Prop24\Prop24\Scripts/angular.js" />
var helloApp = angular.module("helloApp", []);

helloApp.controller("propController", function ($scope) {
    $scope.properties = [];

    $scope.addRow = function () {
        $scope.properties.push({
            'Price': $scope.price, 'Meter Square': $scope.m2, 'Address': $scope.address, 'Title': $scope.title,
            'Description': $scope.description, 'Suburb': $scope.suburb, 'Type': $scope.typee
        });
        $scope.price = '';
        $scope.m2 = '';
        $scope.address = '';
        $scope.title = '';
        $scope.description = '';
        $scope.suburb = '';
        $scope.typee = '';
    };
    $scope.removeRow = function (price) {
        var index = -1;
        var comArr = eval($scope.properties);

        for (var i = 0; i < comArr.length; i++) {
            if (commArr[i].price === price) {
                index = i;
                break;
            }
        }
        if (index === -1) {
            alert("Something went wrong");
        }
        $scope.properties.splice(index, 1);
    };
});