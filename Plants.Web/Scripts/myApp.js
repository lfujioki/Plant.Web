var myApp = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}

};

myApp.moduleOptions = {
    APPNAME: "PlantApp"
        , extraNgDependencies: []
        , runners: []
        , page: myApp.page
}

myApp.layout.startUp = function () {
    console.debug("myApp.layout.startUp");

    //this does a null check on myApp.page.startUp
    if (myApp.page.startUp) {
        console.debug("myApp.page.startUp");
        myApp.page.startUp();
    }
};

myApp.APPNAME = "PlantApp";

$(document).ready(myApp.layout.startUp);
