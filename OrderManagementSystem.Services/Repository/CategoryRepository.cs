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
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _dbContext.CategorySet.ToListAsync();
        }
    }
}
