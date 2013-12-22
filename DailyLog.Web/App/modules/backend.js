define(['durandal/system', 'jquery', 'viewmodels/dayLog'], function (system, jQuery, dayLog)
{
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

            var getLogDataPromise = serverConn.getLogData(date);
            
            var returningViewModelPromise = getLogDataPromise.then(function(data) {
                return new dayLog(data);
            });
            
            return returningViewModelPromise;
        },

        save: function(data)
        {
            return serverConn.save(data);
        },

        activate: function()
        {
            system.log('backend.activate');
        }
    };

    function parseDateString(dateOrString)
    {
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