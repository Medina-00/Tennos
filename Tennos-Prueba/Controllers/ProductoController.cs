using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tennos_Prueba.core.Domain.Entidades;
using Tennos_Prueba.Infraestructura.persistence.Repository;

namespace Tennos_Prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoRepository productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        //esto es para indicar la respuesta por el resultado
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Productos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get()
        {
            var data = await productoRepository.GetAllAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        //esto es para indicar la respuesta por el resultado
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Productos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var data = await productoRepository.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Productos productos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await productoRepository.AddAsync(productos);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Productos))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, Productos productos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await productoRepository.UpdateAsync(productos, id);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //esto es para indicar la respuesta por el resultado
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Productos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await productoRepository.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }
            await productoRepository.DeleteAsync(id);
            return Ok(data);
        }

    }

}
