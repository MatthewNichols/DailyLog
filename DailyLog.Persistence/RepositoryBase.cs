using DailyLog.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DailyLog.Persistence
{
    public abstract class RepositoryBase<T>
    {
        private MongoDatabase _mongoDatabase;

        protected RepositoryBase(string connectionString)
        {
            OpenConnection(connectionString);
        }

        /// <summary>
        /// Create a connection to the DB specifies in the connectionString.
        /// </summary>
        /// <param name="connectionString">Specifies the Db to connect to.</param>
        private void OpenConnection(string connectionString)
        {
            //Use the MongoUrl class to parse the connectionString
            var mongoUrl = new MongoUrl(connectionString);

            //Create a MongoClient with the new mongoUrl object instead of a url string.
            var mongoClient = new MongoClient(mongoUrl);

            //Get a refernce to the server
            var mongoServer = mongoClient.GetServer();
            mongoServer.Connect();

            //Connect to the database using the mongoUrl again but to get the DatabaseName
            _mongoDatabase = mongoServer.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Returns reference to desired MongoCollection.
        /// </summary>
        public MongoCollection<T> GetMongoCollection()
        {
            //Return a reference to the Members collection. Hard coding
            //the collection name is typically ok here, unless we will be storing to 
            //multiple different collections of the same type in the same Db.  In that case it would
            //probably be better to pass the collection name in on the constructor or set it from a 
            //property.
            return _mongoDatabase.GetCollection<T>(CollectionName);
        }

        public abstract string CollectionName { get; }
        
        public T GetById(ObjectId id)
        {
            return GetMongoCollection().FindOneById(id);
        }

        public T Save(T dayLog)
        {
            GetMongoCollection().Save(dayLog);
            return dayLog;
        }
    }
}