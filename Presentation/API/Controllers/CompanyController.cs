using Application.Services;
using Application.ViewModels.Company;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _companyService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost(template: "add")]
        public IActionResult Add(VmCreateCompany vmCreateCompany)
        {
            var result = _companyService.Add(vmCreateCompany);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut(template: "update")]
        public IActionResult Update(VmUpdateCompany vmUpdateCompany)
        {
            var result = _companyService.Update(vmUpdateCompany);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
