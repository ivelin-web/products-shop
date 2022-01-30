namespace App.Configs.Interfaces
{
    using Microsoft.Extensions.Configuration;

    public interface IConfiguration
    {
        IConfigurationRoot Config { get; }
    }
}
