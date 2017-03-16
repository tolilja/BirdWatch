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
                });
        }
    }
})();
