using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public  DbSet<Employee> EmployeeSet{ get; set; }
        public DbSet<Department> DepartmentSet { get; set; }
        public DbSet<Country> CountrySet { get; set; }
        public DbSet<Menu> MenuSet { get; set; }


    }
}
