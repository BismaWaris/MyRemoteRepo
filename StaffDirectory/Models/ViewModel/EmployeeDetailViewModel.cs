using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StaffDirectory.Models.ViewModel;

internal partial class EmployeeDetailViewModel : ObservableObject
{
    [ObservableProperty]
    private Employee employee;

}
