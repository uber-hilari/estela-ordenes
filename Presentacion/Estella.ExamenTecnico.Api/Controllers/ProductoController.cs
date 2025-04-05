using Estela.ExamenTecnico.Aplicacion.Commands.Productos;
using Estela.ExamenTecnico.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estella.ExamenTecnico.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController(IMediator mediator) : Controller
    {
        [HttpPost("")]
        public async Task<IActionResult> CrearProducto([FromBody] CrearProductoRq model)
        {
            await mediator.Send(new CrearProductoCommand { Data = model });
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> ListaProductos([FromQuery] ListaPaginadaRq model)
        {
            var result = await mediator.Send(new ListarProductosCommand { Data = model });
            return Ok(result);
        }
    }
}
