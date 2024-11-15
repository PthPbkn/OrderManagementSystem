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

        public async Task<List<Product>> GetAllProducts()
        {
           return await _context.ProductSet.ToListAsync();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
