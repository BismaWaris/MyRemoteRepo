using StaffDirectory.Pages;
using StaffDirectory.Data;
using System.IO;

namespace StaffDirectory
{
    public partial class App : Application
    {
        public static DatabaseHelper Database;

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Staff.db3");
            Database = new DatabaseHelper(dbPath);

            MainPage = new NavigationPage(new EmployeeListPage());
        }
    }
}