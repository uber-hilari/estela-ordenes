using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Entities
{
    public class Producto : BaseEntity
    {
        public required string Sku { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }

        /// <summary>
        /// Reduce el stock en la cantidad indicada
        /// </summary>
        /// <param name="cantidad">Cantidad a disminuir el stock</param>
        /// <returns>Devuelve True si se pudo reducir el stock, False si la cantidad es mayor al Stock</returns>
        public bool RetirarStock(decimal cantidad)
        {
            Stock -= cantidad;
            return (Stock > 0);
        }
    }
}
