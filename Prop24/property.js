var myProp = angular.module("myProp", []);

myProp.controller("propController", ['$scope', 'AddProperty', function ($scope, AddProperty) {
    $scope.property = {
        price: "",
        m2: "",
        address: "",
        title: "",
        description: "",
        suburb: "",
        typee: "",
        noOfBeds: "",
        noOfBaths: "",
        noOfGarages: ""
    }
    $scope.prop = [];

    $scope.addProp = function () {
        AddProperty.saveProperty($scope.property).then(function () {
            alert("Property added!");
            //GetProperty.get(price, m2, address, suburb)
            window.location.href = "userIndex.html"
        }, function () {
            alert("Property not added. Try again");
        })
    }
}]);

myProp.factory('AddProperty', function ($http) {
    AddProperty = {};
    var urlBase = "http://localhost:15446/Api/"

    AddProperty.saveProperty = function (PropAdd) {
        return $http.post(urlBase + '/Property/', PropAdd)
    }
    return AddProperty;
});

myProp.controller("getPropertyCtrl", ['$scope', 'getService', function ($scope, getService) {
    $scope.property = {
        price: "",
        m2: "",
        address: "",
        title: "",
        description: "",
        suburb: "",
        typee: "",
        noOfBeds: "",
        noOfBaths: "",
        noOfGarages: ""
    }

    GetProperty = function () {
        getService.getProperty($scope.property).then(function () {
            alert("Data Found");
        }, function () {
            alert("Failed");
        })
    }
    //var urlBase = "http:/localhost:15446/Api/Property/"
    //    GetProperty = function()
    //    {
    //        var apiRoute = urlBase + 'GetProperty/';
    //        var _property = getService.GetProp(apiRoute);

    //        _property.then(function (response) {
    //            $scope.property = response.data;
    //        }, function (error) {
    //            alert("Error");
    //        });
    //    }
    //    $scope.GetProperty();
    
}]);

myProp.service('getService', function ($http) {
    getService = {};
    //var urlGet = '';
    var urlBase = "http://localhost:15446/Api/"
    getService.getProperty = function (GetProperty) {
        return $http.get(urlBase + '/Property/', GetProperty)
    }
    return getService;
    //this.GetProp = function (apiRoute) {
    //    urlGet = apiRoute;
    //    return $http.get(urlGet);
    //}
});

