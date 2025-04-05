using Estela.ExamenTecnico.Models.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Commands.Productos
{
    public class CrearProductoCommand : IRequest
    {
        public required CrearProductoRq Data { get; set; }
    }
}
