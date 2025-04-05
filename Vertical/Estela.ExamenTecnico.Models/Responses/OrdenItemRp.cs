using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Models.Responses
{
    public record OrdenItemRp
    {
        public required string Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public required string Glosa { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<LineaOrdenItemRp> Lineas { get; set; } = [];
    }

    public record LineaOrdenItemRp
    {
        public required string IdProducto { get; set; }
        public required string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
