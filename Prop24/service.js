/// <reference path="C:\Users\User\Documents\Prop24\Prop24\Scripts/angular.js" />


var UserService = angular.module("UserService", []);
UserService.factory('UserApi', function ($http) {
    var urlBase = "http://localhost:15446/api/User";
    var UserApi = {};
    
    UserApi.AddUser = function (AddUser) {
        return $http.post(urlBase + '/User/', AddUser);
    };

    //UserApi.EditUser = function (userToUpdate) {
    //    var request = $http({
    //        method: 'put',
    //        url: urlBase + '/User/' + userToUpdate.userID,
    //        data: userToUpdate
    //    });
    //    return request;
    //};

    return UserApi;
});