using BookEcommerceWeb.Models.DTOs;
using FluentValidation;

namespace BookEcommerceWeb.Models.Validation
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Tên danh mục là bắt buộc.")
                .Length(1, 100).WithMessage("Tên danh mục phải dài từ 1 - 100 ký tự.");

            RuleFor(category => category.DisplayOrder)
                .GreaterThanOrEqualTo(1).WithMessage("Thứ tự hiển thị phải lớn hơn 1.");
        }
    }
}
