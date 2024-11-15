using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();

        Task<int> AddEmployee(Employee employee);

        Task<EmployeeViewModel> GetEmployeeByEmployeeID(int id);

        Task<Employee> GetEmployeeByID(int id);

        Task UpdateEmployeeByEmployeeID(Employee employee);
        Task DeleteEmployeeByEmployeeID(int id);

    }
}
