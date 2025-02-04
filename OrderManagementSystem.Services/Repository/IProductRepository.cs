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
        public Task<List<ProductViewModel>> GetAllProducts();
        public Task<ProductViewModel> GetProductById(int id);
        public Task<Product> GetProductByIdForEdit(int id);
        public Task<int> AddProduct(Product product);
        public Task<Product> DeleteProduct(int id);        
        public Task<int> GetLargerProductId();

        public Task<int> UpdateProduct(Product product);

        public Task<int> ContinueDiscontinueProduct(int id);
    

    }
}
