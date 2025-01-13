using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.Models.DTOs;
using BookEcommerceWeb.Models.Models;
using BookEcommerceWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookEcommerceWeb.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategories();
            return Json(new { data = result });
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await _categoryService.GetCategoryDetail(id);
            return Json(new { data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            await _categoryService.CreateCategory(category);
            return Ok(category);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CategoryDto category)
        {
            await _categoryService.UpdateCategory(category);
            return Ok(category);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
