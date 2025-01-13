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
    public class ProductService : IProductService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task CreateProduct(ProductDto productDto)
        {
            var isExists = await _unitofWork.ProductRepository.IsExists(productDto.Id);
            if (isExists)
                throw new Exception("Không thể thêm mới do mặt hàng đã tồn tại");

            var checkCategory = await _unitofWork.CategoryRepository.GetById(productDto.CategoryId);
            if (checkCategory == null)
                throw new Exception("Không thể thêm mới do danh mục hàng hóa không hợp lệ");

            var newProduct = _mapper.Map<Product>(productDto);
            await _unitofWork.ProductRepository.AddAsync(newProduct);
            await _unitofWork.SaveChangeAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _unitofWork.ProductRepository.GetById(id);
            if (product == null)
                throw new Exception("Không thể xóa do mặt hàng không tồn tại");

            _unitofWork.ProductRepository.Remove(product);
            await _unitofWork.SaveChangeAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var productList = _unitofWork.ProductRepository.GetAll();
            var productDTOs = _mapper.Map<List<ProductDto>>(productList);
            return productDTOs;
        }

        public async Task<ProductDto> GetProductDetail(int id)
        {
            var product = await _unitofWork.ProductRepository.GetById(id);
            if (product == null)
                throw new Exception("Không thể tìm thấy do mặt hàng không tồn tại");

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCateId(int cateId)
        {
            var category = await _unitofWork.CategoryRepository.GetById(cateId);
            if (category == null)
                throw new Exception("Không thể tìm thấy do danh mục hàng hóa không tồn tại");

            var products = _unitofWork.ProductRepository.Get(item => item.CategoryId == cateId,"Category");
            var result = _mapper.Map<List<ProductDto>>(products);
            return result;
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var existsProduct = await _unitofWork.ProductRepository.GetById(productDto.Id);
            if (existsProduct == null)
                throw new Exception("Không thể cập nhật do mặt hàng không tồn tại");

            existsProduct = _mapper.Map<Product>(productDto);
            existsProduct.UpdatedDate = DateTime.UtcNow;
            _unitofWork.ProductRepository.Update(existsProduct);
            await _unitofWork.SaveChangeAsync();
        }
    }
}
