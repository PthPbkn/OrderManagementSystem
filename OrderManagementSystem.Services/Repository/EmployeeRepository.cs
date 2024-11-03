using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
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

        public async Task DeleteEmployeeByEmployeeID(int id)
        {
            var employee = await _context.EmployeeSet.FindAsync(id);
            if (employee != null)
            {
                _context.EmployeeSet.Remove(employee);
                await _context.SaveChangesAsync();
            }           
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.EmployeeSet.ToListAsync();
        }

        public async Task<EmployeeViewModel> GetEmployeeByEmployeeID(int id)
        {
            var employee = await (from emp in _context.EmployeeSet
                                  join dept in _context.DepartmentSet on emp.DepartmentID equals dept.DepartmentID
                                  join country in _context.CountrySet on emp.CountryID equals country.CountryID
                                  where emp.EmployeeID == id
                                  select new EmployeeViewModel
                                  {
                                      Title = emp.Title,
                                      Gender = emp.Gender,
                                      HireDate = emp.HireDate,
                                      HouseNumber = emp.HouseNumber,
                                      StreetName = emp.StreetName,
                                      PostCode=emp.PostCode,
                                      Phone=emp.Phone,
                                      ImagePath=emp.ImagePath,
                                      EmployeeID = emp.EmployeeID,  
                                      DepartName = dept.DepartmentName,
                                      CountryName = country.CountryName,
                                      FirstName = emp.FirstName,
                                      LastName = emp.LastName,
                                      BirthDate = emp.BirthDate,    
                                      City = emp.City,                                    


                                  }).FirstOrDefaultAsync();
            return employee;
        }

        public async Task<Employee> GetEmployeeByID(int id)
        {
            var employee = await _context.EmployeeSet.FindAsync(id);
            return employee;
        }

        public async Task UpdateEmployeeByEmployeeID(Employee employee)
        {
            _context.EmployeeSet.Update(employee);
            await _context.SaveChangesAsync();
        }


    }
}
