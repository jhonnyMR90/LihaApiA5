using LihaApiA5.@interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LihaApiA5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteVendedor : ControllerBase
    {
        private readonly IClienteVendedor _ClienteVendedorRepository;

        public ClienteVendedor(IClienteVendedor ClienteVendedorRepsitory)
        {
            _ClienteVendedorRepository = ClienteVendedorRepsitory;
        }

        [Authorize]
        [HttpGet("byPalabra/{NombreUsuarioEmpleado}")]
        public async Task<IActionResult> GetCliente(string NombreUsuarioEmpleado, string NombreApellidoNombreComercial)
        {
            string decodedPalabra = Uri.UnescapeDataString(NombreApellidoNombreComercial);

            var productos = await _ClienteVendedorRepository.GetCliente(NombreUsuarioEmpleado,decodedPalabra);

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }


    }
}
