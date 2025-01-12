using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.Models.Models;
using BookEcommerceWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork _unitofWork;

        public CategoryService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task CreateCategory(Category category)
        {
            var isExists = await _unitofWork.CategoryRepository.IsExists(category.Id);
            if (isExists)
                throw new Exception("Không thể thêm mới do danh mục hàng hóa đã tồn tại");
            
            await _unitofWork.CategoryRepository.AddAsync(category);
        }

        public async Task DelteCategory(int id)
        {
            var category = await _unitofWork.CategoryRepository.GetById(id);
            if (category == null)
                throw new Exception("Không thể xóa do danh mục hàng hóa không tồn tại");

            _unitofWork.CategoryRepository.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return _unitofWork.CategoryRepository.GetAll();
        }

        public async Task<Category> GetCategoryDetail(int id)
        {
            var category = await _unitofWork.CategoryRepository.GetById(id);
            if (category == null)
                throw new Exception("Không thể tìm thấy do danh mục hàng hóa không tồn tại");
            return category;
        }

        public async Task UpdateCategory(Category category)
        {
            var isExists = await _unitofWork.CategoryRepository.IsExists(category.Id);
            if (!isExists)
                throw new Exception("Không thể cập nhật do danh mục hàng hóa không tồn tại");

            _unitofWork.CategoryRepository.Update(category);
        }
    }
}
