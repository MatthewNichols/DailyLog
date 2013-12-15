using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyLog.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DailyLog.Persistence
{
    public class UserSettingsRepository : RepositoryBase<UserSettings>
    {
        public UserSettingsRepository(string connectionString) : base(connectionString)
        {
        }

        public UserSettings GetForUser()
        {
            return GetMongoCollection().AsQueryable().SingleOrDefault();
        }

        public override string CollectionName
        {
            get { return "usersettings"; }
        }
    }
}
