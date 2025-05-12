using LoopLearn.Backend.Database;
using LoopLearn.Backend.Utils;
using LoopLearn.Frontend;
namespace LoopLearn.Backend
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            string connectionString = "Data Source=../../../Backend/Database/LoopLearnDB.db;Version=3;";
            DatabaseService.Instance.Initialize(connectionString);
            AuthForm mainForm = new AuthForm();
            PageManager.Initalize(mainForm);
            Application.Run(mainForm);
        }
    }
}