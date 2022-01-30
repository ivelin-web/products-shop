namespace App
{
    using App.Core;
    using App.Core.Interfaces;

    internal static class StartUp
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}