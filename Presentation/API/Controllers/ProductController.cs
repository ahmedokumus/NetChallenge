using Application.Services;
using Application.ViewModels.Company;
using Application.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost(template: "add")]
        public IActionResult Add(VmCreateProduct vmCreateProduct)
        {
            var result = _productService.Add(vmCreateProduct);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
