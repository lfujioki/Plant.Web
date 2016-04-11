myApp.ng = {
	app: {
		services: {}
		, controllers: {}
	}
    , controllerInstances: []
	, exceptions: {}
	, examples: {}
    , defaultDependencies: ["ngAnimate", "ngRoute"]
    , getModuleDependencies: function () {
    	if (myApp.extraNgDependencies) {
    		var newItems = myApp.ng.defaultDependencies.concat(myApp.extraNgDependencies);
    		return newItems;
    	}
    	return myApp.ng.defaultDependencies;
    }
};

myApp.ng.app.module = angular.module('PlantApp', myApp.ng.getModuleDependencies());

myApp.ng.app.module.value('$myApp', myApp.page);

//#region - base functions and objects -

myApp.ng.exceptions.argumentException = function (msg) {
	this.message = msg;
	var err = new Error();

	console.error(msg + "\n" + err.stack);
}

myApp.ng.app.services.baseEventServiceFactory = function ($rootScope) {
	var factory = this;

	factory.$rootScope = $rootScope;

	factory.eventService = function (eventName) {

		var thisEventService = this;

		thisEventService.eventName = eventName;

		thisEventService.broadcast = function () {
			factory.$rootScope.$broadcast(thisEventService.eventName, arguments)
		}

		thisEventService.emit = function () {
			factory.$rootScope.$emit(thisEventService.eventName, arguments)
		}

		thisEventService.listen = function (callback) {
			factory.$rootScope.$on(thisEventService.eventName, callback)
		}

	}

	return factory.eventService;
}


myApp.ng.app.services.baseService = function ($win, $loc, $util) {
	/*
        when this function is envoked by Angular, Angular wants an instance of the Service object. 
    */

	var getChangeNotifier = function ($scope) {
		/*
			will be called when there is an event outside Angular that has modified
			our data and we need to let Angular know about it.
        */
		var self = this;

		self.scope = $scope;

		// causes ng to re-evaluate bindings
		return function (fx) {
			self.scope.$apply(fx);
		}
	}

	var baseService = {
		$window: $win
        , getNotifier: getChangeNotifier
        , $location: $loc
        , $utils: $util
        , merge: $.extend
	};

	return baseService;
}

myApp.ng.app.controllers.baseController = function ($doc, $logger, $myApp, $route, $routeParams) {
	/*
        this is intended to serve as the base controller
    */
	baseController = {
		$document: $doc
		, $log: $logger
        , $myApp: $myApp
        , merge: $.extend

        , setUpCurrentRequest: function (viewModel) {
        	viewModel.currentRequest = { originalPath: "/", isTop: true };

        	if (viewModel.$route.current) {
        		viewModel.currentRequest = viewModel.$route.current;
        		viewModel.currentRequest.locals = {};
        		viewModel.currentRequest.isTop = false;
        	}

        	viewModel.$log.log("setUpCurrentRequest firing:");
        	viewModel.$log.debug(viewModel.currentRequest);
        }
        , hasFlag: function (check, flag) {
        	return (check & flag) == flag;
        }
	};

	return baseController;
}

//#endregion

//#region  - core ng wrapper functions --

myApp.ng.getControllerInstance = function (jQueryObj) {//used to grab an instance of a controller bound to an Element
	console.log(jQueryObj);
	return angular.element(jQueryObj[0]).controller();
}

myApp.ng.addService = function (ngModule, serviceName, dependencies, factory) {
	/*
		myApp.ng.app.module.service('$baseService', 
			['$window', '$location', '$utils', myApp.ng.app.services.baseService]);
    */
	if (!ngModule ||
		!serviceName || !factory ||
		!angular.isFunction(factory)) {
		throw new myApp.ng.exceptions.argumentException("Invalid Service Call");
	}

	if (dependencies && !angular.isArray(dependencies)) {
		throw new myApp.ng.exceptions.argumentException("Invalid Service Call [dependencies]");
	}
	else if (!dependencies) {
		dependencies = [];
	}

	dependencies.push(factory);

	ngModule.service(serviceName, dependencies);
}

myApp.ng.registerService = myApp.ng.addService;

myApp.ng.addController = function (ngModule, controllerName, dependencies, factory) {
	if (!ngModule ||
		!controllerName || !factory ||
		!angular.isFunction(factory)) {
		throw new myApp.ng.exceptions.argumentException("Invalid Service defined");
	}

	if (dependencies && !angular.isArray(dependencies)) {
		throw new myApp.ng.exceptions.argumentException("Invalid Service Call [dependencies]");
	}
	else if (!dependencies) {
		dependencies = [];
	}

	dependencies.push(factory);
	ngModule.controller(controllerName, dependencies);
}

myApp.ng.registerController = myApp.ng.addController;


//#endregions


//#region - adding in baseService and baseController
/*
	the basic explaination for these three function arguments

	name of thing we are creating:'baseService'
	array containing the dependancies of the function we will use to create said thing
	the last item in this array is invoked to create the object and passed the preceding dependancies.
*/
myApp.ng.addService(myApp.ng.app.module
					, "$baseService"
					, ['$window', '$location']
					, myApp.ng.app.services.baseService);

myApp.ng.addService(myApp.ng.app.module
					, "$eventServiceFactory"
					, ["$rootScope"]
					, myApp.ng.app.services.baseEventServiceFactory);

myApp.ng.addService(myApp.ng.app.module
					, "$baseController"
					, ['$document', '$log', '$myApp', "$route", "$routeParams"]
					, myApp.ng.app.controllers.baseController);


//#endregion
