using System.Windows;
using netproject2.Data;

namespace netproject2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the database on startup
            using (var context = new AppDbContext())
            {
                context.InitializeDatabase(); // This will create the database and tables if they do not exist
            }

            // Continue with application startup logic
        }
    }
}
