// StaffDirectory/Data/DatabaseHelper.cs

using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffDirectory.Models;

namespace StaffDirectory.Data
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employee>().Wait();
        }

        internal Task<List<Employee>> GetEmployeesAsync()
        {
            return _database.Table<Employee>().ToListAsync();
        }

        internal Task<int> SaveEmployeeAsync(Employee employee)
        {
            if (employee.EmployeeID != 0)
            {
                return _database.UpdateAsync(employee);
            }
            else
            {
                return _database.InsertAsync(employee);
            }
        }

        internal Task<int> DeleteEmployeeAsync(Employee employee)
        {
            return _database.DeleteAsync(employee);
        }

        // Add other CRUD operations as needed
    }
}
