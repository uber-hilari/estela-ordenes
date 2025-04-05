using Estela.ExamenTecnico.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Entities
{
    public class Orden : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public string Glosa { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public virtual ICollection<LineaOrden> Lineas { get; set; } = [];

        /// <summary>
        /// Agrega un producto a una orden, se debe incluir la cantidad
        /// </summary>
        /// <param name="producto">Producto a agregar</param>
        /// <param name="cantidad">Cantidad en la orden, debe ser menor al stock disponible</param>
        /// <exception cref="StockInsuficienteException" />
        public void AgregarProducto(Producto producto, decimal cantidad)
        {
            if (!producto.RetirarStock(cantidad))
            {
                throw new StockInsuficienteException(producto.Sku);
            }

            Lineas.Add(new LineaOrden
            {
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio,
                Producto = producto,
                SubTotal = cantidad * producto.Precio
            });
            Total = Lineas.Sum(c => c.SubTotal);
        }

        /// <summary>
        /// Crea una nueva instancia de la Orden asignando las datos necesarios
        /// </summary>
        /// <param name="ultimoNumero">Ultimo numero de orden registrado, se incrementará en 1 al crear una nueva instancia</param>
        /// <param name="glosa">Descripción del motivo de la orden</param>
        /// <returns>Nueva instancia de una orden</returns>
        public static Orden CrearNuevo(int ultimoNumero, string glosa)
        {
            return new Orden
            {
                Fecha = DateTime.UtcNow,
                Numero = ultimoNumero + 1,
                Glosa = glosa
            };
        }
    }
}
