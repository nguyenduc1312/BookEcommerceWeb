using BookEcommerceWeb.DataAccess.Data;
using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _dbContext = db;
        }
    }
}
