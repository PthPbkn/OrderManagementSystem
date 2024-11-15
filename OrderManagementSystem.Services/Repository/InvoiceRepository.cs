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
            throw new NotImplementedException();
        }

        public Task<List<InvoiceViewModel>> GetSuppliers()
        {
            throw new NotImplementedException();
        }
    }
}
