using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace DailyLog.Domain
{
    public class DayLog
    {
        public ObjectId Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("logItems")]
        public IList<LogItem> LogItems { get; set; }

    }
}