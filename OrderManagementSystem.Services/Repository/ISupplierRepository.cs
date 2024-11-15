using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface ISupplierRepository
    {
        public Task<List<Supplier>> GetAllSupplier();
        public Task<int> AddSupplier(Supplier supplier);
        public Task<List<Supplier>> UpdateSupplier(Supplier supplier);
        public Task<List<Supplier>> DeleteSupplier(int id);
    }
}
