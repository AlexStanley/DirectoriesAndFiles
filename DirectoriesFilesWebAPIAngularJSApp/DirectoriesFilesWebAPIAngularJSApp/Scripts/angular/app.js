angular.module("DirectoriesAndFiles", [])
    .controller("TestingController", function ($scope, InitializationDirectory, CurrentDirectory, CurrentDirectoryFiles, ParentDirectory, FilesDirectory) {

        $scope.currentDirectoryValue = "";
        $scope.files = {};
        $scope.directories = {};
        $scope.directoryfiles = {};

        // initialization
        $scope.initialization = function () {
            $scope.currentDirectoryValue = "- - - - -";

            InitializationDirectory.all().success(function (data) {
                $scope.directories = data;
            });

            $scope.directoryfiles = {};

            $scope.files = {};
            $scope.files = { 0: "- - -", 1: "- - -", 2: "- - -" };
        };

        // looking for subdirectories for current directory
        $scope.testingSubdirectory = function (directoryString) {

            if (directoryString.toString().indexOf(".") != -1 || directoryString.toString().indexOf("#") != -1 ||
                directoryString.toString().indexOf("+") != -1 || directoryString.toString().indexOf("&") != -1) {
                alert("Bad syntax! This name cannot be processing!");
            }
            else {
                $scope.files = { 0: "- - -", 1: "- - -", 2: "- - -" };
                $scope.directoryfiles = {};

                $scope.currentDirectoryValue = directoryString;

                var temp = directoryString.substring(0, 1) + directoryString.substring(2);
                var str = temp.split("\\");

                CurrentDirectory.alldirectories(str).success(function (data) {
                    $scope.directories = data;
                });

                CurrentDirectoryFiles.alldirectoryfiles(str).success(function (data) {
                    $scope.directoryfiles = data;
                });

                FilesDirectory.filedirectory(str).success(function (data) {
                    $scope.files = data;
                });
            }
        };

        $scope.parentDirectory = function (currentDirectoryString) {
            $scope.files = { 0: "- - -", 1: "- - -", 2: "- - -" };
            $scope.directoryfiles = {};

            var temp = currentDirectoryString.substring(0, 1) + currentDirectoryString.substring(2);
            var str = temp.split("\\");

            if (temp.toString().length == 2 || currentDirectoryString.toString() == "- - - - -") {
                $scope.initialization();
            }
            else {
                ParentDirectory.directory(str).success(function (data) {
                    $scope.currentDirectoryValue = data;

                    var temp = data.substring(0, 1) + data.substring(2);
                    var str = temp.split("\\");

                    CurrentDirectory.alldirectories(str).success(function (data) {
                        $scope.directories = data;
                    });

                    CurrentDirectoryFiles.alldirectoryfiles(str).success(function (data) {
                        $scope.directoryfiles = data;
                    });

                    FilesDirectory.filedirectory(str).success(function (data) {
                        $scope.files = data;
                    });
                });
            }

        };

    }).factory('InitializationDirectory', function InitializationDirectoryFactory($http) {
    return {
        all: function () {
            return $http({ method: 'GET', url: "http://localhost:52172/api/InitializationDirectory" });
        }
    }
    }).factory('CurrentDirectory', function CurrentDirectoryFactory($http) {
    return {
        alldirectories: function (currentDirectory) {
            return $http({ method: 'GET', url: "http://localhost:52172/api/CurrentDirectory/" + currentDirectory });
        }
    }
    }).factory('CurrentDirectoryFiles', function CurrentDirectoryFilesFactory($http) {
    return {
        alldirectoryfiles: function (currentDirectory) {
            return $http({ method: 'GET', url: "http://localhost:52172/api/CurrentDirectoryFiles/" + currentDirectory });
        }
    }
    }).factory('ParentDirectory', function ParentDirectoryFactory($http) {
    return {
        directory: function (currentDirectory) {
            return $http({ method: 'GET', url: "http://localhost:52172/api/ParentDirectory/" + currentDirectory });
        }
    }
    }).factory('FilesDirectory', function FilesDirectoryFactory($http) {
    return {
        filedirectory: function (currentDirectory) {
            return $http({ method: 'GET', url: "http://localhost:52172/api/FilesDirectory/" + currentDirectory });
        }
    }
});