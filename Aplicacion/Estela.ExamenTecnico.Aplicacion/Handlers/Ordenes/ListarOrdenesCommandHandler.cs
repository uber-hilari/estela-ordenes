using AutoMapper;
using Estela.ExamenTecnico.Aplicacion.Commands.Ordenes;
using Estela.ExamenTecnico.Dominio;
using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Dominio.Services;
using Estela.ExamenTecnico.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Handlers.Ordenes
{
    public class ListarOrdenesCommandHandler(
        IDataReader dataReader,
        IMapper mapper
    ) : IRequestHandler<ListarOrdenesCommand, PagedList<OrdenItemRp>>
    {
        public async Task<PagedList<OrdenItemRp>> Handle(ListarOrdenesCommand request, CancellationToken cancellationToken)
        {
            var lista = await dataReader.GetPagedList<Orden>(request.Data.PaginaActual, request.Data.FilasPorPagina);
            return lista.Map(mapper.Map<Orden, OrdenItemRp>);
        }
    }
}
