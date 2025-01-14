using LihaApiA5.@interface;
using LIhaApiA5.Data.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LihaApiA5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteCartera : ControllerBase
    {
        private readonly IClienteCartera _ClienteCarteraRespository;

        public ClienteCartera(IClienteCartera ClienteCarteraRepository)
        {
            _ClienteCarteraRespository = ClienteCarteraRepository;
        }

        [HttpGet("byCodigoCliente/{CodigoCliente}")]
        public async Task<IActionResult> GetCartera(string CodigoCliente, string CodigoVendedor)
        {
   

            var Cartera = await _ClienteCarteraRespository.GetCartera(CodigoCliente, CodigoVendedor);

            if (Cartera == null)
            {
                return NotFound();
            }

            return Ok(Cartera);
        }







    }
}
