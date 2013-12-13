define(['durandal/app', 'plugins/dialog', 'knockout'], function (app, dialog, ko) {

    var ctor = function()
    {
        var self = this;

        this.displayName = "Hi";
        this.date = new Date();
        this.success = ko.observable(false);
        
        this.okHandler = function()
        {
            self.success(true);
            dialog.close(self, self);
        };

        this.cancelHandler = function()
        {
            dialog.close(self);
        };
    };

    return ctor;
});