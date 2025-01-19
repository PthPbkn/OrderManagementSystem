using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderViewModel>> GetProductsBySupplierId(int Id);
        Task<OrderViewModel> GetProductsByID(int Id);
        Task<List<OrderViewModel>> GetSuppliers();
        Task<OrderViewModel> GetSupplierById(int Id);
        Task<int> AddInvoice(Order order);
        Task<List<Order>> GetInvoices();
        Task<int> GetLargestInvoiceNumber();
    }
}
