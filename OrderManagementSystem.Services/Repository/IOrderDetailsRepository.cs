using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Services.Repository
{
    public interface IOrderDetailsRepository
    {
        Task<int> AddInvoiceDetails(IEnumerable<OrderDetail> orderDetail);

        public Task<List<OrderDetail>> GetOrderDetails(int InvoiceID);

    }

    
}
