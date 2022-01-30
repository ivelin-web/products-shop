namespace App.Core
{
    using App.Core.Interfaces;

    public class Engine : IEngine
    {
        public void Run()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}
