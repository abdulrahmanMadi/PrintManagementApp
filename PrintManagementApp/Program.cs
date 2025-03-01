using PrintManagementApp.Data;
using PrintManagementApp.Forms.Users;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace PrintManagementApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Force database initialization
                Database.SetInitializer(new DatabaseInitializer());
                using (var context = new AppDbContext())
                {
                    context.Database.Initialize(force: true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization failed: {ex.Message}");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
