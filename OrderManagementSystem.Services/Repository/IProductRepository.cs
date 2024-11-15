using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
        public Task<int> AddProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task<Product> DeleteProduct(int id);
    }
}
