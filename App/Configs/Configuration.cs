namespace App.Configs
{
    using Microsoft.Extensions.Configuration;

    public class Configuration : Interfaces.IConfiguration
    {
        public Configuration()
        {
            this.Config = new ConfigurationBuilder()
                .AddUserSecrets<Configuration>()
                .Build();
        }

        public IConfigurationRoot Config { get; private set; }
    }
}
