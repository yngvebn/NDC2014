angular.module('movies').controller('MovieList', [
    '$scope', '$http',
    function ($scope, $http) {
        $scope.movies = [];
        $scope.genres = [];
        $scope.selectedGenre = '';

        $scope.toggleGenre = function (genre) {
            if ($scope.selectedGenre === genre) genre = '';
            $scope.selectedGenre = genre;
        }

        $http.get('/api/v1/movies').success(function (result) {
            $scope.movies = result;
            $scope.genres = _.chain($scope.movies).flatten('genres').uniq().value();
        });
    }
]);