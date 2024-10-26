using OrderManagementSystem.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employees>> GetAllEmployees();
    }
}
