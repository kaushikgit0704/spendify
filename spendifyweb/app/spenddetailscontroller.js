/// <reference path="D:\AngularJS\Services\spendifyservice\spendifyweb\lib/angular.min.js" />
/// <reference path="spendifyapp.js" />
/// <reference path="D:\AngularJS\Services\spendifyservice\spendifyweb\Scripts/_references.js" />
/// <reference path="D:\AngularJS\Services\spendifyservice\spendifyweb\Scripts/angular.intellisense.js" />
/// <reference path="spendifyservices.js" />

spendifyApp.controller('spenddetailscontroller', ['$scope', 'spendifyservices',
    function ($scope, spendifyservices) {
    spendifyservices
        .getspenddetails()
        .then(function (response) {
            $scope.allspenddetails = response.data;
        });

    $scope.addNewSpends = function () {
        if ($scope.spenderName != undefined && 
            $scope.spendDesc != undefined && 
            $scope.amount != undefined && 
            $scope.spendDate != undefined)
            {
                var spendDetail = {};
                spendDetail.spenderName = $scope.spenderName;
                spendDetail.spendDescription = $scope.spendDesc;
                spendDetail.spendAmount = $scope.amount;
                spendDetail.spenddate = $scope.spendDate;                   
                spendifyservices
                    .addspenddetails($scope.allspenddetails)
                    .then(
                        function(response){
                            $scope.allspenddetails.push(spendDetail);
                            $scope.spenderName = null;
                            $scope.spendDesc = null;
                            $scope.amount = null;
                            $scope.spendDate = null;
                        },
                        function(error){
                            alert('Spend Addition Failed !');
                            console.error(error);
                        }
                    );                
            }
    }
}]);