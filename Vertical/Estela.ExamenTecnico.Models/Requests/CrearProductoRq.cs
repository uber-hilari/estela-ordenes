using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Models.Requests
{
    public record CrearProductoRq
    {
        public required string Sku { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
    }
}
