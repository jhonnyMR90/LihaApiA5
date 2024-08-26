using LIhaApiA5.Data.Repositorios;
using LIhaApiA5.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIhaApiA5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Grupo_categoria_lineaController : ControllerBase
    {
        private readonly IGRUPOCATEGORIALINEA _GRUPOCATEGORIALINEA;

        public Grupo_categoria_lineaController(IGRUPOCATEGORIALINEA CategoriasRepository)
        {
            _GRUPOCATEGORIALINEA = CategoriasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            return Ok(await _GRUPOCATEGORIALINEA.GetAllCategorias());
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateCategorias([FromBody] categorias categorias)
        //{
        //    if (categorias == null)
        //        return BadRequest();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var created = await _cateogriasrepository.InsertCategorias(categorias);

        //    return Created("created", created);
        //}  
        
        //[HttpPut]
        //public async Task<IActionResult> UpdateCategorias([FromBody] categorias categorias)
        //{
        //    if (categorias == null)
        //        return BadRequest();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    await _cateogriasrepository.UpdateCategorias(categorias);

        //    return NoContent();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> deletecategorias(string categorias)
        //{
        //    await _cateogriasrepository.DeleteCategorias(new categorias { CodigoCategoria = categorias });

        //    return NoContent();
        //}
    }
}
