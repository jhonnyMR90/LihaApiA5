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

        [HttpGet("byCode/{CodigoVentaProducto}")]
        public async Task<IActionResult> GetDetails(string CodigoVentaProducto)
        {
            string decodedCodigoVentaProducto = Uri.UnescapeDataString(CodigoVentaProducto);

            var productos = await _productospvprepository.GetDetails(decodedCodigoVentaProducto);

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpGet("byDescription/{DescripcionProducto}")]
        public async Task<IActionResult> GetDetailsDescription(string DescripcionProducto)
        {
            string decodedDescripcionProducto = Uri.UnescapeDataString(DescripcionProducto);

            var productos = await _productospvprepository.GetDetailsDescription(decodedDescripcionProducto);

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpGet("byPalabra/{palabra}")]
        public async Task<IActionResult> GetDetailsPalabra(string palabra)
        {
            string decodedPalabra = Uri.UnescapeDataString(palabra);

            var productos = await _productospvprepository.GetDetailsPalabra(decodedPalabra);

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }








    }
}
