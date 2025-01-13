using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.Models.DTOs;
using BookEcommerceWeb.Models.Models;
using BookEcommerceWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookEcommerceWeb.Controllers
{
    [Route("/api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyService.GetAllCompanies();
            return Json(new { data = result });
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await _companyService.GetCompanyDetail(id);
            return Json(new { data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CompanyDto company)
        {
            await _companyService.CreateCompany(company);
            return Ok(company);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CompanyDto company)
        {
            await _companyService.UpdateCompany(company);
            return Ok(company);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteCompany(id);
            return Ok();
        }
    }
}
