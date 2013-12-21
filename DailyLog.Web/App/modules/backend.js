define(['durandal/system','jquery'], function (system, jQuery) {

    var firstTime = true;
    var serverConn = jQuery.connection.logData.server;
    
    return {

        setup: function()
        {
            system.log('backend.setup');
            return jQuery.connection.hub.start();
        },
        
        getData: function(date)
        {
            date = parseDateString(date);
            
            return serverConn.getLogData(date);
        },

        save: function(dayLog)
        {
            return serverConn.save(dayLog);
        },

        activate: function()
        {
            system.log('backend.activate');
        }
    };

    function parseDateString(dateOrString)
    {
        console.log("dateString", typeof(dateOrString));
        var date = new Date();
        if (typeof(dateOrString) == "string")
        {
            var dateParts = dateOrString.split('-');
            var yearIndex = 2, monthIndex = 1, dayIndex = 0;
            var yearNum = parseInt(dateParts[yearIndex]), monthNum = parseInt(dateParts[monthIndex]), dayNum = parseInt(dateParts[dayIndex]);
            date = new Date(yearNum, monthNum - 1, dayNum);
        }
        if (typeof(dateOrString) == "object")
        {
            date = dateOrString;
        }
        
        return date;
    }
    
});