(function() {
    var app = angular.module("SubmissionApp", ['ngSanitize', 'ui.tinymce']);

    app.controller('SubmissionController',['$http', '$scope', '$location',
        function ($http, $scope, $location) {
            $scope.tinymceModel = 'Initial content';
            $scope.tinymceOptions = {
                plugins: 'link image code lists',
                toolbar: 'undo redo | bold italic underline | alignleft aligncenter alignright | numlist bullist | code'
            };
            $scope.content = '';
            $scope.title = 'Untitled';
            $scope.url = '/Submission/Submit';
            $scope.method = 'POST';
            $scope.submitPost = function () {
                console.log('Posting post');
                $scope.code = '';
                $scope.response = '';
                let date = new Date();
                let dateTime = date.getFullYear() +
                    '-' +
                    (date.getMonth() + 1) +
                    '-' +
                    date.getDate() +
                    ' ' +
                    date.getHours() +
                    ':' +
                    date.getMinutes();


                $scope.postedOn = '';
                $http({
                    method: $scope.method,
                    url: $scope.url,
                    data: {
                        'PostedOn': dateTime,
                        'Title': $scope.title,
                        'Content': $scope.content
            }
                }).then(function (response) {
                    console.log(dateTime);
                    $scope.status = response.status;
                    $scope.data = response.data;
                    console.log('Success!');
                    $location.path('/Home/Index');
                }, function (response) {
                    $scope.data = response.data || 'Request failed';
                    $scope.status = response.status;
                    console.log('Nope! ' + response.status);
                });
            };
        }]);


})();

