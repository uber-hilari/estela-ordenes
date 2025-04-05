using Estela.ExamenTecnico.Aplicacion.Commands.Ordenes;
using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Dominio.Services;
using Estela.ExamenTecnico.Dominio.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Handlers.Ordenes
{
    public class CrearOrdenCommandHandler(
        IDataReader dataReader,
        IDataWriter dataWriter,
        IUltimoNumeroOrdenQuery ultimoNumeroOrdenQuery
    ) : IRequestHandler<CrearOrdenCommand>
    {
        public async Task Handle(CrearOrdenCommand request, CancellationToken cancellationToken)
        {
            var ultimoNumero = await ultimoNumeroOrdenQuery.Execute();

            var nuevaOrden = Orden.CrearNuevo(ultimoNumero, request.Data.Glosa);

            foreach (var linea in request.Data.Lineas)
            {
                var producto = await dataReader.Get(ProductoSpecification.ConId(linea.IdProducto.Guid()).ToExpression());
                nuevaOrden.AgregarProducto(producto, linea.Cantidad);
            }

            await dataWriter.Agregar(nuevaOrden);
        }
    }
}
