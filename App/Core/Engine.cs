namespace App.Core
{
    using App.Configs.Databases.Interfaces;
    using App.Core.Interfaces;

    public class Engine : IEngine
    {
        private readonly IDatabase mongo;

        public Engine(IDatabase mongo)
        {
            this.mongo = mongo;
        }

        public void Run()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login(this.mongo));
        }
    }
}
