using LihaApiA5.@interface;
using LIhaApiA5.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LihaApiA5.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItem _items;

        public ItemController(IItem itemrepository)
        {
            _items = itemrepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItem()
        {

            return Ok(await _items.GetAllItem());
        }
    }
}
