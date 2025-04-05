using Estela.ExamenTecnico.Models.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Commands.Ordenes
{
    public class CrearOrdenCommand: IRequest
    {
        public required CrearOrdenRq Data { get; set; }
    }
}
