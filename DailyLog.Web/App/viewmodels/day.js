﻿define(['durandal/system', 'durandal/app', 'modules/backend', 'viewmodels/dayPickerDialog'], function (system, app, backend, dayPicker) {
    var ctor = function ()
    {
        var self = this;
        
        this.displayName = 'Day Log';

        this.pickDay = function()
        {
            var dpVm = new dayPicker();
            var showDialogResult = app.showDialog(dpVm);

            showDialogResult.done(function() {               
                var dataPromise = backend.getData(dpVm.date);
                dataPromise.done(function (data) {
                    self.data = data;
                });
            });

            return showDialogResult;
        };

        this.save = function()
        {
            backend.save(self.data);
        };

        this.activate = function (dateString) {
            system.log('day.activate');
            
            var dataPromise = backend.getData(dateString);
            dataPromise.done(function(data)
            {                
                self.data = data;
            });   
        };
        
    };

    //Note: This module exports a function. That means that you, the developer, can create multiple instances.
    //This pattern is also recognized by Durandal so that it can create instances on demand.
    //If you wish to create a singleton, you should export an object instead of a function.
    //See the "flickr" module for an example of object export.

    return ctor;
});