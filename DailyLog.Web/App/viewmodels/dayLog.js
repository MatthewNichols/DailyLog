define([], function() {

    var ctor = function(data)
    {
        var self = this;

        this.date = data.date;

        this.logItems = data.logItems || [];
    };

    return ctor;

});