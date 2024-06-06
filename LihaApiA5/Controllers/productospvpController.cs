using LIhaApiA5.Data.Repositorios;
using LIhaApiA5.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIhaApiA5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productospvpController : ControllerBase
    {
        private readonly Iproductospvp _productospvprepository;

        public productospvpController(Iproductospvp ProductospvpRepository)
        {
            _productospvprepository = ProductospvpRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            return Ok(await _productospvprepository.GetAllProductos());
        }

        [HttpGet("{CodigoVentaProducto}")]
        public async Task<IActionResult> GetDetails(string CodigoVentaProducto)
        {
            return Ok(await _productospvprepository.GetDetails(CodigoVentaProducto));
        }
    }
}
