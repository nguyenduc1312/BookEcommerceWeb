using BookEcommerceWeb.Models.DTOs;
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
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryDetail(int id);
        Task CreateCategory(CategoryDto category);
        Task UpdateCategory(CategoryDto category);
        Task DeleteCategory(int id);
    }
}
