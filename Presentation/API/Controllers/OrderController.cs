using Application.Services;
using Application.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet(template:"getall")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost(template: "create")]
        public IActionResult Create(VmCreateOrder vmCreateOrder)
        {
            var result = _orderService.Create(vmCreateOrder);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
