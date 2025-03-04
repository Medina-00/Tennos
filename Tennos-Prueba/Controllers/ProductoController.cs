using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tennos_Prueba.core.Domain.Entidades;
using Tennos_Prueba.Infraestructura.persistence.Repository;

namespace Tennos_Prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Mantenimiento de Productos")]

    public class ProductoController : Controller
    {
        private readonly IProductoRepository productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Listado de Productos",
          Description = "Obtiene todos los Producto creados"
        )]
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
        [SwaggerOperation(
          Summary = "Producto Por Id",
          Description = "Obtiene el producto Por El Id"
        )]

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
        [SwaggerOperation(
          Summary = "Crear un Producto",
          Description = "Recibe Los Parementro que se Necesita para Crear Un Producto"
        )]

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
                Validaciones.Validaciones.ValidarCamposGuardar(productos);
                await productoRepository.AddAsync(productos);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
          Summary = "Actualizar un Producto",
          Description = "Recibe Los Parementro que se Necesita para Actualizar un Producto"
        )]

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
                Validaciones.Validaciones.ValidarCamposUpdate(productos);
                await productoRepository.UpdateAsync(productos, id);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
              Summary = "Eliminar un Producto",
              Description = "Recibe los parametros necesarios para eliminar un Producto existente" 
        )]
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
