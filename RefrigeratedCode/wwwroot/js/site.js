(function() {
    var app = angular.module("MainApp", ['ngSanitize']);

    app.controller('MainController', ['$scope', '$http', function($scope, $http) {
        $scope.method = 'GET';
        $scope.url = '/Home/GetPosts?currentPostCount=';
        $scope.postCount = 0;

        $scope.fetch = function() {
            $scope.code = '';
            $scope.response = '';
            $scope.url += $scope.postCount;
            $http({
                method: $scope.method,
                url: $scope.url,
            }).then(function(response) {
                $scope.status = response.status;
                $scope.posts = response.data;
            }, function(response) {
                $scope.data = response.data || 'Request failed';
                $scope.status = response.status;
            });
        };
        $scope.fetch();
        $scope.formatDate = formatDate;


    }]);
})();

