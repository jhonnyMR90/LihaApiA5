using LihaApiA5.@interface;
using LIhaApiA5.Data.Repositorios;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize]
        [HttpGet("byCartera/{CodigoCliente}")]
        public async Task<IActionResult> GetCartera(string CodigoCliente, string UsuarioVendedor)
        {
   

            var Cartera = await _ClienteCarteraRespository.GetCartera(CodigoCliente, UsuarioVendedor);

            if (Cartera == null)
            {
                return NotFound();
            }

            return Ok(Cartera);
        }

        [Authorize]
        [HttpGet("byCupo/{CodigoCliente}")]
        public async Task<IActionResult> GetCupo(string CodigoCliente)
        {


            var Cupo = await _ClienteCarteraRespository.GetCupo(CodigoCliente);

            if (Cupo == null)
            {
                return NotFound();
            }

            return Ok(Cupo);
        }










    }
}
