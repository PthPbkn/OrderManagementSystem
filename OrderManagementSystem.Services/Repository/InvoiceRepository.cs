using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Task<List<InvoiceViewModel>> GetProducts()
        {
            
            var products = new List<InvoiceViewModel>();
            throw new NotImplementedException();
        }

        public async Task<InvoiceViewModel> GetSuppliers()
        {
            //return await _context.SupplierSet.ToListAsync();

            var suppliers = await (from supplier in _context.SupplierSet select new InvoiceViewModel
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Address = supplier.Address,
                City = supplier.City,
                PostCode = supplier.PostCode,
                Phone = supplier.Phone,
            }).FirstOrDefaultAsync();
            return suppliers;            
        }

        
    }
}
