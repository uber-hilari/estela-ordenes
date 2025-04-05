using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Models.Requests
{
    public record CrearOrdenRq
    {
        public required string Glosa { get; set; }
        public IEnumerable<LineaCrearOrdenRq> Lineas { get; set; } = [];
    }

    public record LineaCrearOrdenRq
    {
        public required string IdProducto { get; set; }
        public decimal Cantidad { get; set; }
    }
}
