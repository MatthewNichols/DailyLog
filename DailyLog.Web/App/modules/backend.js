define(['durandal/system'], function (system) {

    var firstTime = true;
    
    return {
        
        getData: function(date)
        {
            date = parseDateString(date);
            
            var returnEntries = firstTime ? ["First", "Second", "Third"] : ["First 2", "Second 2", "Third 2"];

            firstTime = false;

            return {
                date: date,
                entries:  returnEntries
            };
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