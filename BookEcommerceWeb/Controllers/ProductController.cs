using BookEcommerceWeb.Models.DTOs;
using BookEcommerceWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookEcommerceWeb.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            await _productService.CreateProduct(productDto);
            return Ok(productDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
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
