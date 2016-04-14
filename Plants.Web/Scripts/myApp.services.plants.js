myApp.services.plants = myApp.services.plants || {};

myApp.services.plants.add = function (plantData, onSuccess, onError) {
    var url = "/api/plants";

    var settings = {
        cache: false
    	, contentType: "application/x-www-form-urlencoded; charset=UTF-8"
	    , data: plantData
    	, dataType: "json"
	    , success: onSuccess
	    , error: onError
	    , type: "POST"
    };

    $.ajax(url, settings);
}

// if plantId is included in data, then just the plantdata obj
myApp.services.plants.update = function (plantId, plantData, onSuccess, onError) {
    var url = "/api/plants/" + plantId;

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: plantData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
    };

    $.ajax(url, settings);
}

myApp.services.plants.get = function (onSuccess, onError) {
    var url = "/api/plants";

    var settings = {
        cache: false
    	, contentType: "application/x-www-form-urlencoded; charset=UTF-8"
	    , data: null
    	, dataType: "json"
	    , success: onSuccess
	    , error: onError
	    , type: "GET"
    };

    $.ajax(url, settings);
}

myApp.services.plants.getById = function (plantId, onSuccess, onError) {
    var url = "/api/plants/" + plantId;

    var settings = {
        cache: false
    	, contentType: "application/x-www-form-urlencoded; charset=UTF-8"
	    , data: plantId
    	, dataType: "json"
	    , success: onSuccess
	    , error: onError
	    , type: "GET"
    };

    $.ajax(url, settings);
}