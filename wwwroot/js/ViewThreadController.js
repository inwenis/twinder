(function() {
    "use strict";
    angular.module("ViewThread")
        .controller("ViewThreadController", ViewThreadController);

    function ViewThreadController($http) {

        var vm = this;

        vm.Messages = [
            {
                Content: "ala ma kota",
                Author: "john",
                Created: new Date()
            },
            {
                Content: "hellow world",
                Author: "Jack",
                Created: new Date()
            }
        ];

        vm.NewMessage = {};

        $http.get("/api/messages")
        .then(function(response) {
            //success
            angular.copy(response.data, vm.Messages);
            vm.Messages.forEach(function (element) {
                element.showAllReplies = false;
            });
            }, function() {
            //failure
        });

        $http.get("/api/isLoggedIn")
            .then(function(response) {
                if (response.data)
                {
                    vm.isLoggedIn = true;
                }
                else
                {
                    vm.isLoggedIn = false;
                }
            },
            function() {
            });

        vm.GetMessages = function() {
            $http.get("/api/messages")
            .then(function (response) {
                //success
                angular.copy(response.data, vm.Messages);
            }, function () {
                //failure
            });
        }

        vm.AddMessage = function() {
            //send it to the database
            if (!vm.isLoggedIn) {
                alert("set user name");
                return;
            }
            $http.post("/api/messages", vm.NewMessage)
                .then(function (response) {
                    vm.Messages.unshift(response.data);
                    vm.NewMessage = {};
                }, function() {
                    alert("failure");
                });
        }

        vm.ShowAllReplies = function(id) {
            vm.Messages.filter(function(element) {
                return element.id == id;
            })[0].showAllReplies = true;
        }

        vm.HideReplies = function(id) {
            vm.Messages.filter(function (element) {
                return element.id == id;
            })[0].showAllReplies = false;
        }

        vm.Reply = function (id) {
            //send to server TODO
            if (!vm.isLoggedIn) {
                alert("set user name");
                return;
            }
            var newReply = vm.Messages.filter(function (element) {
                return element.id == id;
            })[0].NewReply;
            $http.post("/api/messages/" + id + "/addReply", newReply)
                .then(function (response) {
                    var message = vm.Messages.filter(function(element) {
                        return element.id == id;
                    })[0];
                    message.replies.push(response.data);
                    message.NewReply.content = "";
                }, function() {
                    alert("failure");
                });
        }
    }
})();
