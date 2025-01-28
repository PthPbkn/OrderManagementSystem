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
                                     
                                  }).ToListAsync();
            return products;
        }

        public async Task<int> GetLargerProductId()
        {
            var prodId = await _context.ProductSet.MaxAsync(x => x.ProductId);
            return prodId;
        }

        public Task<List<Product>> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
