using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DailyLog.Domain
{
    public class UserSettings
    {
        public ObjectId Id { get; set; }
        public IList<LogItem> DefaultLogItems { get; set; }
    }
}
