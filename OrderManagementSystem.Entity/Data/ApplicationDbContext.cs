using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity.Data
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public  DbSet<Employee> EmployeeSet{ get; set; }
        public DbSet<Department> DepartmentSet { get; set; }
        public DbSet<Country> CountrySet { get; set; }
        public DbSet<Menu> MenuSet { get; set; }
        public DbSet<Customer> CustomerSet { get; set; }


    }
}
