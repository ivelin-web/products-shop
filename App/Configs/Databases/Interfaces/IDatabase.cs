namespace App.Configs.Databases.Interfaces
{
    using MongoDB.Driver;

    public interface IDatabase
    {
        public IMongoDatabase Db { get; }
    }
}
