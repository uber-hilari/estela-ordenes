using AutoMapper;
using Estela.ExamenTecnico.Aplicacion.Commands.Productos;
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

namespace Estela.ExamenTecnico.Aplicacion.Handlers.Productos
{
    public class ListarProductosCommandHandler(
        IMapper mapper,
        IDataReader dataReader
    ) : IRequestHandler<ListarProductosCommand, PagedList<ProductoItemRp>>
    {
        public async Task<PagedList<ProductoItemRp>> Handle(ListarProductosCommand request, CancellationToken cancellationToken)
        {
            var lista = await dataReader.GetPagedList<Producto>(request.Data.PaginaActual, request.Data.FilasPorPagina);
            return lista.Map(mapper.Map<Producto, ProductoItemRp>);
        }
    }
}
