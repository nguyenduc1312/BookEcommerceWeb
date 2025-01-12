using AutoMapper;
using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.Models.DTOs;
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
        private readonly IMapper _mapper;

        public CategoryService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task CreateCategory(CategoryDto categoryDto)
        {
            var isExists = await _unitofWork.CategoryRepository.IsExists(categoryDto.Id);
            if (isExists)
                throw new Exception("Không thể thêm mới do danh mục hàng hóa đã tồn tại");
            
            var newCategory = _mapper.Map<Category>(categoryDto);
            await _unitofWork.CategoryRepository.AddAsync(newCategory);
            await _unitofWork.SaveChangeAsync();
        }

        public async Task DelteCategory(int id)
        {
            var category = await _unitofWork.CategoryRepository.GetById(id);
            if (category == null)
                throw new Exception("Không thể xóa do danh mục hàng hóa không tồn tại");

            _unitofWork.CategoryRepository.Remove(category);
            await _unitofWork.SaveChangeAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categoryList = _unitofWork.CategoryRepository.GetAll();
            var categoryDTOs = _mapper.Map<List<CategoryDto>>(categoryList);
            return categoryDTOs;
        }

        public async Task<CategoryDto> GetCategoryDetail(int id)
        {
            var category = await _unitofWork.CategoryRepository.GetById(id);
            if (category == null)
                throw new Exception("Không thể tìm thấy do danh mục hàng hóa không tồn tại");

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var existsCategory = await _unitofWork.CategoryRepository.GetById(categoryDto.Id);
            if (existsCategory == null)
                throw new Exception("Không thể cập nhật do danh mục hàng hóa không tồn tại");

            existsCategory = _mapper.Map<Category>(categoryDto);
            existsCategory.UpdatedDate = DateTime.UtcNow;
            _unitofWork.CategoryRepository.Update(existsCategory);
            await _unitofWork.SaveChangeAsync();
        }
    }
}
