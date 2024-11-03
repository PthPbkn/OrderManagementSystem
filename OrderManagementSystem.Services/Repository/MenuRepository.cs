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
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public Task<List<Menu>> GetAllMenu()
        {
            var model = _context.MenuSet.Where(m=>m.IsActive == true).ToListAsync();
            return model;
        }
    }
}
