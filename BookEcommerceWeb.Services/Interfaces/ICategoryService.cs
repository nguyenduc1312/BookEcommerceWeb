using BookEcommerceWeb.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryDetail(int id);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DelteCategory(int id);
    }
}
