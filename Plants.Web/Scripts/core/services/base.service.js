(function () {
    "use strict";

    angular.module(APPNAME)
    .factory('$baseService', baseServiceFactory);

    baseServiceFactory.$inject = ['$window', '$location'];

    function baseServiceFactory($window, $location) {

         function getChangeNotifier ($scopeFromController) {

             function NotifyConstructor($s)
             {
                 var self = this;

                 self.scope = $s;

                 return function (fx) {
                     self.scope.$apply(fx);
                 }
             }

             return new NotifyConstructor($scopeFromController);
        }

        var baseService = {
            $window: $window
            , getNotifier: getChangeNotifier
            , $location: $location
            , merge: $.extend
        };

        return baseService;
    }
})();