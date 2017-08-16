var app = angular.module('mypost', []);

app.controller("mypostcontroller", function ($scope, $http) {
    $scope.form = [];
    $scope.files = [];

    $scope.insert = function () {
        $scope.image1 = $scope.files1[0];
        $scope.image2 = $scope.files2[0];
        $scope.image3 = $scope.files3[0];
        $scope.image4 = $scope.files4[0];

        $http({
            method: "POST",
            url: "User/AddPictures.html",
            processData: false,
            transformrequest: function (data) {
                var formData = new FormData();

                formData.append("image1", $scope.image1);
                formData.append("image2", $scope.image2);
                formData.append("image3", $scope.image3);
                formData.append("image4", $scope.image4);

                return formData;
            },
            data: $scope.form,
            headers: {
                'Content-Type': undefined
            }
        }).then(function (data) {
            alert(data);
        });
    };

    $scope.uploadedFile = function(element)
    {
        $scope.currentFile = element.files[0];
        var rdr = new FileReader();

        rdr.onload = function (event) {
            var output = document.getElementById('output');
            output.src = URL.createObjectURL(element.files[0]);

            $scope.image_source = event.target.result
            $scope.$apply(function ($scope) {
                $scope.files = element.files;
            });
        }
        rdr.readAsDataURL(element.files[0]);
    }

    $scope.uploadedFile2 = function(element)
    {
        $scope.currentFile2 = element.files[0];
        var rdr = new FileReader();

        rdr.onload = function (event) {
            var output1 = document.getElementById('output1');
            output1.src = URL.createObjectURL(element.files[0]);
            $scope.image_source = event.target.result
            $scope.$apply(function ($scope) {
                $scope.files2 = element.files;
            });
        }
        rdr.readAsDataURL(element.files[0]);
    }

    $scope.uploadedFile3 = function(element)
    {
        $scope.currentFile3 = element.files[0];
        var rdr = new FileReader();

        rdr.onload = function (event) {
            var output3 = document.getElementById('output3');
            output3.src = URL.createObjectURL(element.files[0]);
            $scope.image_source = event.target.result
            $scope.$apply(function ($scope) {
                $scope.files3 = element.files;
            });
        }
        rdr.readAsDataURL(element.files[0]);
    }

    $scope.uploadedFile4 = function(element)
    {
        $scope.currentFile4 = element.files[0];
        var rdr = new FileReader();

        rdr.onload = function (event) {
            var output4 = document.getElementById('output4');
            output4.src = URL.createObjectURL(element.files[0]);
            $scope.image_source = event.target.result
            $scope.$apply(function ($scope) {
                $scope.files4 = element.files;
            });
        }
    }
})