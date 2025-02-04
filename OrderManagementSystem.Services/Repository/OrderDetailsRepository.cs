using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        public async Task<List<OrderViewModel>> GetOrderDetails(int id) 
            {
              //var data = await _dbContext.OrderDetailsSet.Where(m => m.OrderID == id).ToListAsync();


            var data = await (from orderDetails in _dbContext.OrderDetailsSet
                                  join products in _dbContext.ProductSet on orderDetails.ProductID equals products.ProductId
                                  where orderDetails.OrderID == id
                                  select new OrderViewModel
                                  {                                      
                                      ProductName = products.ProductName,
                                      UnitPrice = orderDetails.UnitPrice,
                                      Quantity = orderDetails.Quantity,
                                      ItemTotal = orderDetails.ItemTotal,
                                  }).ToListAsync();

            return data;
            }


    }
}
