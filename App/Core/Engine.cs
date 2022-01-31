namespace App.Core
{
    using App.Configs.Databases.Interfaces;
    using App.Core.Interfaces;
    using App.Utils.PasswordHashes.Interfaces;

    public class Engine : IEngine
    {
        private readonly IDatabase mongo;
        private readonly IPasswordHash passwordHash;

        public Engine(IDatabase mongo, IPasswordHash passwordHash)
        {
            this.mongo = mongo;
            this.passwordHash = passwordHash;   
        }

        public void Run()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Login(this.mongo, this.passwordHash));
            Application.Run(new Main(this.mongo, this.passwordHash));
        }
    }
}
