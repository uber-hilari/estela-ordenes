using Estela.ExamenTecnico.Aplicacion.Commands.Ordenes;
using Estela.ExamenTecnico.Aplicacion.Handlers.Ordenes;
using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Dominio.Exceptions;
using Estela.ExamenTecnico.Dominio.Services;
using Estela.ExamenTecnico.Models.Requests;
using Estela.ExamenTecnico.Models.Responses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Tests.Handlers.Ordenes
{
    public class CrearOrdenCommandHandlerTests
    {
        private readonly Mock<IDataReader> _dataReaderMock;
        private readonly Mock<IDataWriter> _dataWriterMock;
        private readonly Mock<IUltimoNumeroOrdenQuery> _queryMock;

        public CrearOrdenCommandHandlerTests()
        {
            _dataReaderMock = new();
            _dataWriterMock = new();
            _queryMock = new();
        }

        private CrearOrdenCommand GenerarCommand() => new CrearOrdenCommand
        {
            Data = new CrearOrdenRq
            {
                Glosa = "Prueba de Orden",
                Lineas = [
                        new LineaCrearOrdenRq {
                            IdProducto = "ytxKJQfV0EZRqgjddF4TAw",
                            Cantidad = 20
                        }
                    ]
            }
        };

        [Fact]
        public async Task Handle_Should_ReturnSuccess()
        {
            _dataReaderMock.Setup(c => c.Get(It.IsAny<Expression<Func<Producto, bool>>>()))
                .ReturnsAsync(new Producto { Sku = "PRD002", Nombre = "Producto Dos", Precio = 15, Stock = 220 });

            var command = GenerarCommand();

            var handler = new CrearOrdenCommandHandler(_dataReaderMock.Object, _dataWriterMock.Object, _queryMock.Object);

            await handler.Handle(command, CancellationToken.None);

            _dataWriterMock.Verify(c => c.Agregar(It.IsAny<Orden>()), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_ThrowsException_IdProductNotExists()
        {
            _dataReaderMock.Setup(c => c.Get(It.IsAny<Expression<Func<Producto, bool>>>()))
                .ThrowsAsync(new NotFoundEntityException(nameof(Producto)));

            var command = GenerarCommand();

            var handler = new CrearOrdenCommandHandler(_dataReaderMock.Object, _dataWriterMock.Object, _queryMock.Object);

            await Assert.ThrowsAsync<NotFoundEntityException>(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            });
        }
    }
}
