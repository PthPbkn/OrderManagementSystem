using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<int> AddProduct(Product product)
        {
            _context.ProductSet.Add(product);
            int result = await _context.SaveChangesAsync();
            return result;
        }

        public Task<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> Details(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var products = await (from prdts in _context.ProductSet
                                  join category in _context.CategorySet on prdts.CategoryId equals category.CategoryId
                                  orderby prdts.ProductId descending
                                  select new ProductViewModel
                                  {
                                      ImagePath = prdts.ImagePath,
                                      ProductName = prdts.ProductName,
                                      QuantityPerUnit = prdts.QuantityPerUnit,
                                      UnitPrice = prdts.UnitPrice,
                                      UnitsInStock = prdts.UnitsInStock,
                                      UnitsOnOrder = prdts.UnitsOnOrder,
                                      Discontinued = prdts.Discontinued,
                                      CategoryName = category.CategoryName,
                                      ProductId = prdts.ProductId,
                                     
                                  }).ToListAsync();
            return products;
        }

        public async Task<int> GetLargerProductId()
        {
            var prodId = await _context.ProductSet.MaxAsync(x => x.ProductId);
            return prodId;
        }

         public async Task<ProductViewModel> GetProductById(int id)
        {
            var product = await (from products in _context.ProductSet
                                 join category in _context.CategorySet on products.CategoryId equals category.CategoryId
                                 join supplier in _context.SupplierSet on products.SupplierId equals supplier.SupplierId
                                 where products.ProductId == id
                                 select new ProductViewModel
                                 {
                                     ImagePath = products.ImagePath,
                                     ProductName = products.ProductName,
                                     QuantityPerUnit = products.QuantityPerUnit,
                                     UnitPrice = products.UnitPrice,
                                     UnitsInStock = products.UnitsInStock,
                                     UnitsOnOrder = products.UnitsOnOrder,
                                     Discontinued = products.Discontinued,
                                     CategoryName = category.CategoryName,
                                     SupplierName = supplier.SupplierName,
                                     ProductId= products.ProductId,

                                 }).FirstOrDefaultAsync();
            return product;
        }

        public async Task<int> UpdateProduct(Product product)
        {
                _context.ProductSet.Update(product);
                return await _context.SaveChangesAsync();


        }

        public async Task<int> ContinueDiscontinueProduct(int prodId)
        {
            var status = 0;
            var prodct = await _context.ProductSet.FirstOrDefaultAsync(x => x.ProductId == prodId);
            if (prodct != null) 
            {
                if (prodct.Discontinued == false) 
                {
                    prodct.Discontinued = true;
                } 
                else
                {
                    prodct.Discontinued = false;

                }
                status = await _context.SaveChangesAsync();                
            }
            return status;                       
        }


        public async Task<Product> GetProductByIdForEdit(int id)
        {
            var result = await _context.ProductSet.FindAsync(id);
            return result;
        }

        
    }
}
