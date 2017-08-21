/// <reference path="C:\Users\User\Documents\Prop24\Prop24\Scripts/angular.js" />

var signupApp = angular.module('signUpApp', []);

signupApp.controller('signupController', ['$scope', '$window', 'signupService', function ($scope, $window, signupService) {
    $scope.registration = {
        Email: "",
        Password: ""
    }

    $scope.signUp = function () {
        signupService.saveRegistration($scope.registration).then(function () {
            alert("Registered. Click 'OK' to Login");
            window.location.href = "Login.html";
        }, function () {
            alert("Failed");
        })
    }
}]);

signupApp.factory('signupService', function ($http) {
    signupService = {};
    var urlBase = "http://localhost:15446/api/User"
    signupService.saveRegistration = function (AddUser) {
        return $http.post(urlBase + '/User/', AddUser)
    }
    return signupService;
});

signupApp.controller('updateController', ['$scope', '$rootScope', '$window', 'upDateService', function ($scope, $rootScope, $window, upDateService) {
    $scope.btnText = "Update";
    $rootScope.logged;
    $scope.upDate = function () {
        $scope.btnText = "Please Wait...";
        $scope.labelValue = logged.email
        upDateService.saveUpdate({name: $scope.name, mobileNumber: $scope.mobileNumber, password: $scope.password,area: $scope.area, province: $scope.province}).then(function (response) {
            if (response.data == null)
            {
                alert("Failed to upload profile, Try Again");
                $scope.name = undefined;
                $scope.mobileNumber = undefined;
                $scope.password = undefined;
                $scope.area = undefined;
                $scope.province = undefined;
            }
            else
            {
                alert("Profile Updated " + response.data.name);
                window.location.href = "../userIndex.html";
            }
        })
    }
}]);

signupApp.factory('upDateService', function ($http) {
    upDateService = {};
    var urlBase = "http://localhost:15446/Api/update"

    upDateService.saveUpdate = function (name, mobileNumber, password, area, province) {
        return $http.put(urlBase + "?name=" + name + "&mobileNumber=" + mobileNumber + "&password=" + password + "&area=" + area + "&province=" + province)
    }
    return upDateService;
});

signupApp.controller('getprop',['$scope', '$http', function ($scope, $http) {
    $http.get("http://localhost:15446/api/prop")
        .then(function (data) {
            $scope.propertytable = data.data;
        });

    $scope.getHouse = function () {
        $scope.propertyModel = this.x;
        $('#myModalView').modal('show');
    }
}]);

signupApp.controller("propController", ['$scope', 'AddProperty', function ($scope, AddProperty) {
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
        noOfGarages: "",
        image1: "",
        image2: "",
        image3: "",
        image4: ""
    }
    $scope.prop = [];

    $scope.addProp = function () {
        AddProperty.saveProperty($scope.property).then(function () {
            alert("Property added!. Click 'OK' to add images to the property");
            window.location.href = "User/AddPictures.html"
        }, function () {
            alert("Property not added. Try again");
        })
    }
}]);

signupApp.factory('AddProperty', function ($http) {
    AddProperty = {};
    var urlBase = "http://localhost:15446/Api/"

    AddProperty.saveProperty = function (PropAdd) {
        return $http.post(urlBase + '/Property/', PropAdd)
    }
    return AddProperty;
});

signupApp.directive('ngFiles', ['$parse', function ($parse) {
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);

        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        })
    }
    return {
        link: fn_link
    }
}])

signupApp.controller('imageController', function ($scope, $http) {
    var formData = new FormData();
    $scope.getFiles = function ($files) {
        $scope.imagesrc = [];

        for (var i = 0; i < $files.length; i++) {
            var rdr = new FileReader();
            rdr.fileName = $files[i].name;

            rdr.onload = function (event) {
                var image = {};
                image.name = event.target.fileName;
                image.size = (event.total / 1024).toFixed(2);
                image.Src = event.target.result;
                $scope.iamgesrc.push(image);
                $scope.$apply();
            }
            rdr.readAsDataURL($files[i]);
        }

        angular.forEach($files, function (value, key) {
            formdata.append(key, value);
        })
    }

    $scope.uploadFiles = function () {
        var request = {
            method: 'POST',
            url: 'api/Image',
            data: formdata,
            headers: {
                'Content-Type': undefined
            }
        };
        $http(request).then(function (d) {
            alert(d);
        }).error(function () {
            alert("Failed");
        })
    }
})

signupApp.service('uploadFile', ['$http', function ($http) {
    this.uploadFiletoServer = function (file, uploadUrl) {
        var fd = new FormData();
        fd.append('file', file);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined, 'Process-Data': false }
        }).then(function () {
            alert("Image/s Added!");
            }), function () {
            alert("Error");
        };
    }
}]);

signupApp.controller('ImageCtrl', ['$scope', 'uploadFile', function ($scope, uploadFile) {
    $scope.uploadFile = function () {
        $scope.myFile = $scope.files[0];
        var file = $scope.myFile;
        var urlBase = "http://localhost:15446/api/Image";
        uploadFile.uploadFiletoServer(file, urlBase);
    };
    $scope.uploadedFile = function (element) {
        var reader = new FileReader();
        reader.onload = function (event) {
            $scope.$apply(function ($scope) {
                $scope.files = element.files;
                $scope.src = event.target.result
            });
        }
        reader.readAsDataURL(element.files[0]);
    }
}]);