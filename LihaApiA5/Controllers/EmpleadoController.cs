using LihaApiA5.@interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LihaApiA5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly Iempleado _empleado;

        public EmpleadoController(Iempleado empladorepsitory)
        {
            _empleado = empladorepsitory;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllEmpleados()
        {

            return Ok(await _empleado.GetAllEmpleados());
        }
    }
}
