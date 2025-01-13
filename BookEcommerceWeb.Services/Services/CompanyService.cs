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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task CreateCompany(CompanyDto companyDto)
        {
            var isExists = await _unitofWork.CompanyRepository.IsExists(companyDto.Id);
            if (isExists)
                throw new Exception("Không thể đăng ký mới do công ty đã được đăng ký");

            await ValidateInformation(companyDto);
            var newCompany = _mapper.Map<Company>(companyDto);
            await _unitofWork.CompanyRepository.AddAsync(newCompany);
            await _unitofWork.SaveChangeAsync();
        }

        public async Task DeleteCompany(int id)
        {
            var company = await _unitofWork.CompanyRepository.GetById(id);
            if (company == null)
                throw new Exception("Không thể xóa do công ty chưa được đăng ký");

            _unitofWork.CompanyRepository.Remove(company);
            await _unitofWork.SaveChangeAsync();
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {
            var companyList = _unitofWork.CompanyRepository.GetAll();
            var companyDTOs = _mapper.Map<List<CompanyDto>>(companyList);
            return companyDTOs;
        }

        public async Task<CompanyDto> GetCompanyDetail(int id)
        {
            var company = await _unitofWork.CompanyRepository.GetById(id);
            if (company == null)
                throw new Exception("Không thể tìm thấy do công ty chưa được đăng ký");

            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public async Task UpdateCompany(CompanyDto companyDto)
        {
            var existsCompany = await _unitofWork.CompanyRepository.GetById(companyDto.Id);
            if (existsCompany == null)
                throw new Exception("Không thể cập nhật do công ty chưa được đăng ký");

            await ValidateInformation(companyDto);

            existsCompany = _mapper.Map<Company>(companyDto);
            existsCompany.UpdatedDate = DateTime.UtcNow;
            _unitofWork.CompanyRepository.Update(existsCompany);
            await _unitofWork.SaveChangeAsync();
        }

        public async Task ValidateInformation(CompanyDto companyDto)
        {
            var checkEmail = _unitofWork.CompanyRepository.Get(item => item.Email == companyDto.Email && item.Id != companyDto.Id);
            if(checkEmail.Any())
                throw new Exception("Email được nhập đã được đăng ký trước đó");

            var checkPhoneNumber = _unitofWork.CompanyRepository.Get(item => item.PhoneNumber == companyDto.PhoneNumber && item.Id != companyDto.Id);
            if (checkPhoneNumber.Any())
                throw new Exception("Số điện thoại được nhập đã được đăng ký trước đó");
        }
    }
}
