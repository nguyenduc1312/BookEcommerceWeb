using BookEcommerceWeb.Models.DTOs;
using FluentValidation;

namespace BookEcommerceWeb.Models.Validation
{
    public class CompanyValidator : AbstractValidator<CompanyDto>
    {
        public CompanyValidator()
        {
            RuleFor(company => company.Name)
                .NotEmpty().WithMessage("Tên công ty là bắt buộc.")
                .Length(1, 100).WithMessage("Tên công ty phải dài từ 1 - 100 ký tự.");

            RuleFor(company => company.Province)
                .NotEmpty().WithMessage("Tỉnh/Thành phố là bắt buộc.");

            RuleFor(company => company.District)
                .NotEmpty().WithMessage("Quận/huyện là bắt buộc.");

            RuleFor(company => company.Commune)
                .NotEmpty().WithMessage("Xã/Phườnglà bắt buộc.");

            RuleFor(company => company.Address)
                .NotEmpty().WithMessage("Địa chỉ chi tiết là bắt buộc.");

            RuleFor(company => company.PhoneNumber)
                .NotEmpty().WithMessage("Số điện thoại là bắt buộc.");

            RuleFor(company => company.Email)
                .NotEmpty().WithMessage("Địa chỉ Email là bắt buộc.")
                .EmailAddress().WithMessage("Địa chỉ Email không hợp lệ.");
        }
    }
}
