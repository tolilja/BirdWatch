(function () {
    'use strict';

    angular
        .module('birdWatchApp')
        .controller('birdWatchController', birdWatchController);

    birdWatchController.$inject = ['$scope', '$http'];

    function birdWatchController($scope, $http) {
        $scope.title = 'birdWatchController';
        
        activate();

        function activate() {
            $http.get('BirdWatchService.asmx/GetBirdWatchData')
                .then(function (response) {
                    $scope.data = response.data;
                    $scope.name = "laji";
                });
        }

        $scope.incrementBirdObservations = function (item) {
            item.BirdObservations++;
            $http.post('BirdWatchService.asmx/IncrementBirdObservations', { birdName: item.BirdName });
        }

        $scope.addNewBirdItem = function () {
            $http.post('BirdWatchService.asmx/AddNewBirdItem', { birdName: $scope.name });
        }

        $scope.getBirdObservationReport = function () {
            $http.get('BirdWatchService.asmx/GetBirdObservationReport')
                .then(function (response) {
                    $scope.report = response.data;
                });
        }
    }
})();
