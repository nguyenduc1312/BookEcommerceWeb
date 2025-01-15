using BookEcommerceWeb.Models.DTOs;
using FluentValidation;

namespace BookEcommerceWeb.Models.Validation
{
    public class ProductValidator: AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Tên sản phẩm là bắt buộc.")
                .Length(1, 100).WithMessage("Tên sản phầm phải dài từ 1 - 100 ký tự.");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Giá là bắt buộc.");

            RuleFor(product => product.Price50)
                .NotEmpty().WithMessage("Giá 50~100 là bắt buộc.");

            RuleFor(product => product.Price100)
                .NotEmpty().WithMessage("Giá 100 là bắt buộc.");

            RuleFor(product => product.CategoryId)
                .NotEmpty().WithMessage("Sản phẩm bắt buộc phải được đăng ký cho một danh mục sản phẩm.");
        }
    }
}
