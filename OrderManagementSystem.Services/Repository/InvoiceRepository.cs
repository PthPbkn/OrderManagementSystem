using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<InvoiceViewModel>> GetSuppliers()
        {
            var suppliers = await (from supplier in _context.SupplierSet select new InvoiceViewModel
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Address = supplier.Address,
                City = supplier.City,
                PostCode = supplier.PostCode,
                Phone = supplier.Phone,
            }).ToListAsync();
            return suppliers;            
        }

        public async Task<List<InvoiceViewModel>> GetProductsBySupplierId(int Id)
        {
            var products = await (from prd in _context.ProductSet
                                  join splr in _context.SupplierSet on prd.SupplierId equals splr.SupplierId
                                  where splr.SupplierId == Id
                                  select new InvoiceViewModel
                                  {
                                      ProductID = prd.ProductId,
                                      ProductName = prd.ProductName,
                                   }).ToListAsync();
            return products;
        }

        public async Task<InvoiceViewModel> GetSupplierById(int Id)  //  this should be here OR supplier repo?
        {
            var supplier = await (from splr in _context.SupplierSet
                                  where splr.SupplierId == Id
                                  select new InvoiceViewModel
                                  {
                                      Address = splr.Address,
                                      City = splr.City,
                                      PostCode = splr.PostCode,
                                      Phone = splr.Phone,
                                  }).FirstAsync();
            return supplier;
        }

        public async Task<InvoiceViewModel> GetProductsByID(int Id)
        {
            var products = await (from prod in _context.ProductSet
                                  where prod.ProductId == Id
                                  select new InvoiceViewModel
                                  {
                                      UnitPrice = prod.UnitPrice,
                                      UnitsInStock = prod.UnitsInStock,
                                  }).FirstAsync();
            return products;
        }


        public async Task<int> AddInvoice(Invoice invoice)
        {
            _context.InvoiceSet.Add(invoice);
            int result = await _context.SaveChangesAsync();
            return result;
            
        }

        public async Task<List<Invoice>> GetInvoices()
        {
            return await _context.InvoiceSet.ToListAsync();
        }
    }
}
