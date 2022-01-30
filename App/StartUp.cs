namespace App
{
    using App.Configs;
    using App.Configs.Databases;
    using App.Configs.Databases.Interfaces;
    using App.Configs.Interfaces;
    using App.Core;
    using App.Core.Interfaces;
    using App.Utils.PasswordHashes;
    using App.Utils.PasswordHashes.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class StartUp
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IEngine engine = serviceProvider.GetService<IEngine>();
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IEngine, Engine>();
            serviceCollection.AddTransient<IPasswordHash, PasswordHashSha>();
            serviceCollection.AddSingleton<IConfiguration, Configuration>();
            serviceCollection.AddSingleton<IDatabase, MongoDb>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}