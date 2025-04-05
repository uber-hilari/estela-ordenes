using Estela.ExamenTecnico.Aplicacion.Commands.Ordenes;
using Estela.ExamenTecnico.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estella.ExamenTecnico.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdenController (IMediator mediator): Controller
    {
        [HttpPost("")]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenRq model)
        {
            await mediator.Send(new CrearOrdenCommand { Data = model });
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> ListarOrdenes([FromQuery] ListaPaginadaRq model)
        {
            var result = await mediator.Send(new ListarOrdenesCommand { Data = model });
            return Ok(result);
        }
    }
}
