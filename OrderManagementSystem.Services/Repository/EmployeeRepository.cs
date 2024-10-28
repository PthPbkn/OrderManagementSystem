using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            _context.EmployeeSet.Add(employee);
            int result = await _context.SaveChangesAsync();
            return result;
        }

      

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.EmployeeSet.ToListAsync();
        }

   
    }
}
