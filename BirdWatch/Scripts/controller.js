(function () {
    'use strict';

    angular
        .module('birdWatchApp')
        .controller('birdWatchController', birdWatchController);

    birdWatchController.$inject = ['$scope', '$http', '$window'];

    function birdWatchController($scope, $http, $window) {
        $scope.title = 'birdWatchController';

        activate();

        function activate() {
            $http.get('BirdWatchService.asmx/GetBirdWatchData')
                .then(function (response) {
                    $scope.data = response.data;
                });
            $http.get('BirdWatchService.asmx/GetBirdObservationReport')
                .then(function (response) {
                    $scope.report = response.data;
                });
            $scope.name = "";
        }

        $scope.incrementBirdObservations = function (item) {
            $http.post('BirdWatchService.asmx/IncrementBirdObservations', { birdName: item.BirdName })
                .then(function (response) {
                    $scope.status = response.data;
                    activate();
                },
                function (response) {
                    $scope.status = reason;
                });
        }

        $scope.addNewBirdItem = function () {
            $http.post('BirdWatchService.asmx/AddNewBirdItem', { birdName: $scope.name })
                .then(function (response) {
                    $scope.status = response.data;
                    activate();
                },
                function (response) {
                    $scope.status = reason;
                });
        }
    }
})();
