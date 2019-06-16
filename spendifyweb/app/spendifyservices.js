/// <reference path="D:\AngularJS\Services\spendifyservice\spendifyweb\lib/angular.min.js" />
/// <reference path="spenddetailscontroller.js" />
/// <reference path="spendifyapp.js" />

spendifyApp.factory('spendifyservices', ['$http',
    function ($http) {
        var spendifyfactory = {};
        spendifyfactory.getspenddetails = function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:49419/api/getAllSpends'
            });
        };

        spendifyfactory.addspenddetails = function(allspenddetails){
            return $http({
                method: 'POST',
                url: 'http://localhost:49419/api/addSpends',
                data: allspenddetails
            });
        };
        
        return spendifyfactory;
    }
]);