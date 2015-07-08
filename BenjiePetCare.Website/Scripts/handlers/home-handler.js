'use strict'

//controller defined as class
function HomeController() {
    var self = this;

    //constructor
    this.init = function () {
        console.log('initialize HomeController()');
    }

    //handle all events
    this.HandleEvents = function () {
        $('#main').on('click', '.search-btn', function () {
            console.log('.search-btn clicked');

            var targetURL = '/home/getpets';
            var ajaxRequest = $.getJSON(targetURL, function (data) {
                console.log(data);
            });
        });
    }
}//end HomeController()

//on window load 
$(function () {
    var homeController = new HomeController();
    homeController.init();
    homeController.HandleEvents();
});
