using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace DailyLog.Web.Hubs
{
    public class LogData : Hub
    {
        public DayLog GetLogData(DateTime date)
        {
            return new DayLog
            {
                Date = date,
                LogItems = new List<LogItem>
                {
                    new LogItem {Name = "Push Ups", Number = 0},
                    new LogItem {Name = "Sit Ups", Number = 0},
                }
            };
        }
    }

    public class DayLog
    {
        public DateTime Date { get; set; }
        public IList<LogItem> LogItems { get; set; }

    }

    public class LogItem
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
}