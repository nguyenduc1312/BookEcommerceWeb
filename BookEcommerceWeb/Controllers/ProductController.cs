using BookEcommerceWeb.Models.DTOs;
using BookEcommerceWeb.Models.Models;
using BookEcommerceWeb.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookEcommerceWeb.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private IValidator<ProductDto> _validator;
        public ProductController(IProductService productService, IValidator<ProductDto> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllProducts();
            return Json(new { data = result });
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await _productService.GetProductDetail(id);
            return Json(new { data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductDto productDto)
        {
            ValidationResult result = await _validator.ValidateAsync(productDto);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _productService.CreateProduct(productDto);
            return Ok(productDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            ValidationResult result = await _validator.ValidateAsync(productDto);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _productService.UpdateProduct(productDto);
            return Ok(productDto);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("get-by-cate")]
        public async Task<IActionResult> GetByCate(int cateId)
        {
            await _productService.GetProductsByCateId(cateId);
            return Ok();
        }
    }
}
