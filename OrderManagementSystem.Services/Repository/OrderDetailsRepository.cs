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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDetailsRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<int> AddInvoiceDetails(IEnumerable<OrderDetail> orderDetail)
        {

            try
            {
                _dbContext.OrderDetailsSet.AddRange(orderDetail);
                int result = await _dbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public async Task<List<OrderDetail>> GetOrderDetails(int invoiceId) 
            {
                var data = _dbContext.OrderDetailsSet.Where(k => k.InvoiceID == invoiceId).ToList();
                return data;
            }

        
    }
}
