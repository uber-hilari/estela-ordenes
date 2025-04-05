using Estela.ExamenTecnico.Dominio;
using Estela.ExamenTecnico.Models.Requests;
using Estela.ExamenTecnico.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Commands.Productos
{
    public class ListarProductosCommand : IRequest<PagedList<ProductoItemRp>>
    {
        public required ListaPaginadaRq Data { get; set; }
    }
}
