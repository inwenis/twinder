(function() {
    "use strict";

    angular.module("LoginPartial")
        .controller("LoginController", LoginController);

    function LoginController($http) {
        var vm = this;
        vm.username = "";
        $http.get("/api/isLoggedIn")
            .then(function (response) {
                if (response.data) {
                    vm.isLoggedIn = true;
                    vm.username = response.data;
                }
                else {
                    vm.isLoggedIn = false;
                    vm.username = "";
                }
            },
            function () {
            });

        vm.LogIn = function() {
            if (vm.username) {
                //tutaj skonczylem
            }
        }
    }

    angular.bootstrap(document.getElementById("App2"), ['LoginPartial']);
})();