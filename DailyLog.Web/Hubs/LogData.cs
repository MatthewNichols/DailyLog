using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("logItems")]
        public IList<LogItem> LogItems { get; set; }

    }

    public class LogItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }
    }
}