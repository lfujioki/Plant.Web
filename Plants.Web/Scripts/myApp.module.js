(function (appName, currentPageObject, extraNgDependencies, moduleOptions) {
    "use strict";

    //  https://github.com/johnpapa/angular-styleguide#moduleOptionss
    var defaultDependencies = [
        'ngRoute',
        'ngAnimate',
        'toastr'
    ];

    var app = angular.module(appName, getModuleDependencies());

    app.value('$myApp', currentPageObject);

    processModuleOptions(moduleOptions, app);

    function getModuleDependencies() {
        if (extraNgDependencies) {
            var newItems = defaultDependencies.concat(extraNgDependencies);
            return newItems;
        }
        return defaultDependencies;
    }

    function processModuleOptions(options, clientApp) {
        if (!options)
        {
            return;
        }

        if (options.runners) {
            for (var i = 0; i < options.runners.length; i++) {
                var runner = options.runners[i];
                clientApp.run(runner);
            }
        }


    }

})(myApp.APPNAME, myApp.page, myApp.extraNgDependencies, myApp.moduleOptions);