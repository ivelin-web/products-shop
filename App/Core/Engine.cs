namespace App.Core
{
    using App.Core.Interfaces;
    using Microsoft.Extensions.Configuration;

    public class Engine : IEngine
    {
        public void Run()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}
