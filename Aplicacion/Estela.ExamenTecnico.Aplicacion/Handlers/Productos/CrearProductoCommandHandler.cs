using AutoMapper;
using Estela.ExamenTecnico.Aplicacion.Commands.Productos;
using Estela.ExamenTecnico.Dominio;
using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Dominio.Exceptions;
using Estela.ExamenTecnico.Dominio.Services;
using Estela.ExamenTecnico.Dominio.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Handlers.Productos
{
    public class CrearProductoCommandHandler (
        IMapper mapper,
        IDataReader dataReader,
        IDataWriter dataWriter
    ) : IRequestHandler<CrearProductoCommand>
    {
        public async Task Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {
            var productoExistente = await dataReader.GetOrNull(ProductoSpecification.IdentificadoPor(request.Data.Sku).ToExpression());
            if (productoExistente != null)
            {
                throw new InvalidCommandException([
                    new Error(40010, "El sku ya existe")
                ]);
            }

            var productoNuevo = mapper.Map<Producto>(request.Data);
            await dataWriter.Agregar(productoNuevo);
        }
    }
}
