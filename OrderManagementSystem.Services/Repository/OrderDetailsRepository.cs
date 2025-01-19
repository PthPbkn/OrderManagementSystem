using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
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
            catch (Exception ex)
            {

                return 0;
            }
        }
    }
}
