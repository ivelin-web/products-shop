namespace App.Configs.Databases
{
    using App.Configs.Databases.Interfaces;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;

    public class MongoDb : IDatabase
    {
        private readonly string dbName = "products_shop_db";
        private readonly Configs.Interfaces.IConfiguration configuration;
        private readonly IMongoClient client;

        public MongoDb(Configs.Interfaces.IConfiguration configuration)
        {
            this.configuration = configuration;

            this.client = new MongoClient(this.configuration.Config.GetConnectionString("MONGO_URL"));
            this.Db = this.client.GetDatabase(dbName);
        }

        public IMongoDatabase Db { get; private set; }
    }
}
