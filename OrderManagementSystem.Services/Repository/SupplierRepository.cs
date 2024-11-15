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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context) 
        {
            this._context = context;
        }

        public async Task<int> AddSupplier(Supplier supplier)
        {
            _context.SupplierSet.Add(supplier);
            int result = await _context.SaveChangesAsync();
            return result;
        }

        public Task<List<Supplier>> DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Supplier>> GetAllSupplier()
        {
            return await _context.SupplierSet.ToListAsync();
        }

        public Task<List<Supplier>> UpdateSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
