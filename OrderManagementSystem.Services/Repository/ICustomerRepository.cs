using OrderManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers(); 

        
    }
}
