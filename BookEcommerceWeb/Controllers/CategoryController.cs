using System;
using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.Models.DTOs;
using BookEcommerceWeb.Models.Models;
using BookEcommerceWeb.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookEcommerceWeb.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private IValidator<CategoryDto> _validator;

        public CategoryController(ICategoryService categoryService, IValidator<CategoryDto> validator)
        {
            _categoryService = categoryService;
            _validator = validator;
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
        public async Task<IActionResult> Add([FromBody]CategoryDto category)
        {
            ValidationResult result = await _validator.ValidateAsync(category);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _categoryService.CreateCategory(category);
            return Ok(category);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CategoryDto category)
        {
            ValidationResult result = await _validator.ValidateAsync(category);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
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
