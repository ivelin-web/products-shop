namespace App.Configs.Databases.Interfaces
{
    using MongoDB.Driver;

    public interface IDatabase
    {
        public MongoClient Client { get; }

        public IMongoDatabase Db { get; }
    }
}
