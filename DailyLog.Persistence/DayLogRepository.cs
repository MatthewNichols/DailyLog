using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyLog.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace DailyLog.Persistence
{
    public class DayLogRepository : RepositoryBase<DayLog>
    {

        public DayLogRepository(string connectionString) : base(connectionString)
        { }

        public DayLog GetByDate(DateTime date)
        {
            var dayLogs = GetMongoCollection().AsQueryable().Where(log => log.Date == date);
            return dayLogs.Any() ? dayLogs.Single() : null;
        }

        public override DayLog Save(DayLog dayLog)
        {
            var query = Query<DayLog>.EQ(dl => dl.Date, dayLog.Date);
            var update = Update<DayLog>.Replace(dayLog);
            GetMongoCollection().Update(query, update, UpdateFlags.Upsert);

            return dayLog;
        }

        public override string CollectionName
        {
            get { return "logdata"; }
        }
    }
}
