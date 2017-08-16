/// <reference path="C:\Users\User\Documents\Prop24\Prop24\Scripts/angular.js" />
var app;
(function () {
    app = angular.module("RESTClientModule", ['ngAnimate'])
})();

app.controller("ImageController", function ($scope, $rootScope, $window, $http, FileUploadService) {
    $scope.date = new Date();
    $scope.name = "";
    $scope.description = "";

    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";

        $scope.CheckFieldValid($scope.SelectedFileForUpload);

        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload).then(function (d) {
                var IteDetails = {
                    Name: $scope.name,
                    Description: $scope.description
                };
                $http.post('/api/Image/', IteDetails).then(function (data) {
                    alert("Added Successfully");
                    $scope.addMode = false;
                    $scope.loading = false;
                }).error(function (data) {
                    $scope.error = "An error has occured while adding image! " + data;
                    $scope.loading = false;
                });
                alert(d.Message + " Item Saved!");
                $scope.IsFormSubmitted = false;
                ClearForm();
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "Fields Required";
        }
    };
})

app.factory('FileUploadService', function ($http, $q) {
    var fac = {};
    fac.UploadFile = function (file) {
        var formData = new FormData();
        formData.append("file", file);

        var defer = $q.defer();
        $http.post("/Image/insertImage", formData, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        }).then(function (d) {
            defer.resolve(d);
        }).error(function () {
            defer.reject("File Upload failed");
        });
        return defer.promise;
    }
})