using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using StaffDirectory.Models;
using StaffDirectory.Data;
using System.Windows.Input;

namespace StaffDirectory.Models.ViewModel
{
    internal partial class EmployeesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Employee> employees = new();

        [ObservableProperty]
        private Employee employee = new();

        public EmployeesViewModel()
        {
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            var employeesFromDb = await App.Database.GetEmployeesAsync();
            foreach (var emp in employeesFromDb)
            {
                Employees.Add(emp);
            }
        }

        [RelayCommand]
        private async Task Add()
        {
            await App.Database.SaveEmployeeAsync(Employee);
            Employees.Add(Employee);
            Employee = new();
        }

        [RelayCommand]
        public async Task RemoveEmployee(Employee employeeToRemove)
        {
            await App.Database.DeleteEmployeeAsync(employeeToRemove);
            Employees.Remove(employeeToRemove);
        }

        


    }
}
