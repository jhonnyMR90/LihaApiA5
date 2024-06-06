using LIhaApiA5.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIhaApiA5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            return Ok("INGRESADO PUBLICO");
        }
    }

}
