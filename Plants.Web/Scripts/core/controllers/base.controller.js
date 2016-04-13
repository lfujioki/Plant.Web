(function () {
    "use strict";

    angular.module(APPNAME)
    .factory('$baseController', BaseController);

    BaseController.$inject = [
        '$document'
        , '$log'
        , '$route'
        , '$routeParams'
        , '$systemEventService'
        , '$alertService'
        , '$myApp'
    ];

    function BaseController(
        $document,
        $log,
        $route,
        $routeParams,
        $systemEventService,
        $alertService,
        $myApp
        ) {

        var thisController = this;

        var base = {
            $document: $document
            , $log: $log
            , merge: $.extend
            , map: $.map
            , $myApp: $myApp
            , $route: $route
            , $routeParams: $routeParams
            , $systemEventService: $systemEventService
            , $alertService: $alertService

        };

        thisController.hasFlag = _hasFlag;
        thisController.setUpCurrentRequest = _setUpCurrentRequest;
        thisController.getParentController = _getParentController;

        function _getParentController(controllerName) {
            var controller = null;

            if (this.$scope && this.$scope.$parent) {
                controller = this.$scope.$parent[controllerName];
            }

            return controller;
        }


        function _setUpCurrentRequest(viewModel) {
            viewModel.currentRequest = { originalPath: "/", isTop: true };

            if (viewModel.$route.current) {
                viewModel.currentRequest = viewModel.$route.current;
                viewModel.currentRequest.locals = {};
                viewModel.currentRequest.isTop = false;
            }

            viewModel.$log.log("setUpCurrentRequest firing:");
            viewModel.$log.debug(viewModel.currentRequest);
        }

        function _hasFlag(check, flag) {
            return (check & flag) == flag;
        }

        thisController = $.extend(thisController, base);

        return thisController;
    }
})();