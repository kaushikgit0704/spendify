/// <reference path="spendifyapp.js" />
/// <reference path="spenddetailscontroller.js" />
/// <reference path="spenddetails.html" />

spendifyApp.directive('spendDetails', function () {
    return {
        restrict: 'AEC',
        transclude: 'true',
        templateUrl: 'spenddetails.html',
        controller: 'spenddetailscontroller'
    };
});