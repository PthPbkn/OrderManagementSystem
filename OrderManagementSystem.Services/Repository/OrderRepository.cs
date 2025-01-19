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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<OrderViewModel>> GetSuppliers()
        {
            var suppliers = await (from supplier in _context.SupplierSet
                                   select new OrderViewModel
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

        public async Task<List<OrderViewModel>> GetProductsBySupplierId(int Id)
        {
            var products = await (from prd in _context.ProductSet
                                  join splr in _context.SupplierSet on prd.SupplierId equals splr.SupplierId
                                  where splr.SupplierId == Id
                                  select new OrderViewModel
                                  {
                                      ProductID = prd.ProductId,
                                      ProductName = prd.ProductName,
                                  }).ToListAsync();
            return products;
        }

        public async Task<OrderViewModel> GetSupplierById(int Id)  //  this should be here OR supplier repo?
        {
            var supplier = await (from splr in _context.SupplierSet
                                  where splr.SupplierId == Id
                                  select new OrderViewModel
                                  {
                                      Address = splr.Address,
                                      City = splr.City,
                                      PostCode = splr.PostCode,
                                      Phone = splr.Phone,
                                  }).FirstAsync();
            return supplier;
        }

        public async Task<OrderViewModel> GetProductsByID(int Id)
        {
            var products = await (from prod in _context.ProductSet
                                  where prod.ProductId == Id
                                  select new OrderViewModel
                                  {
                                      UnitPrice = prod.UnitPrice,
                                      UnitsInStock = prod.UnitsInStock,
                                  }).FirstAsync();
            return products;
        }


        public async Task<int> AddInvoice(Order order)
        {
            _context.OrderSet.Add(order);
            int result = await _context.SaveChangesAsync();
            return result;

        }

        public async Task<List<Order>> GetInvoices()
        {
            return await _context.OrderSet.OrderByDescending(o => o.OrderID).ToListAsync();   
        }

        public async Task<int> GetLargestInvoiceNumber()
        {
            //var invID = await (from inv in _context.OrderSet select inv).Max(x => x.InvoiceID);
            //return invID;
            //return await _context.OrderSet.Max(x => x.InvoiceID);
            return 105000;
        }
    }
}
