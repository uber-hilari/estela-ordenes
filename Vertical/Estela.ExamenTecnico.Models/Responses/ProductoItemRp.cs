using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Models.Responses
{
    public record ProductoItemRp
    {
        public required string Id { get; set; }
        public required string Sku { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
    }
}
