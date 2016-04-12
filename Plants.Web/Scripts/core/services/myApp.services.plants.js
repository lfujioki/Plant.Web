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