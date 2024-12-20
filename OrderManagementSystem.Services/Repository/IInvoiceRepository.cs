using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceViewModel>> GetProductsBySupplierId(int Id);
        Task<InvoiceViewModel> GetProductsByID(int Id);
        Task<List<InvoiceViewModel>> GetSuppliers();
        Task<InvoiceViewModel> GetSupplierById(int Id);
        Task<int> AddInvoice(Invoice invoice);
        Task<List<Invoice>> GetInvoices();


    }
}
