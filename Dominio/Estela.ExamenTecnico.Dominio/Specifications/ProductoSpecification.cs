using Estela.ExamenTecnico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Specifications
{
    public static class ProductoSpecification
    {
        /// <summary>
        /// Representa el filtrado de productos por ID
        /// </summary>
        /// <param name="id">Id a filtrar</param>
        /// <returns>Specification de filtrado de productos por ID</returns>
        public static Specification<Producto> ConId(Guid id) =>
            new ExprSpecification<Producto>(p => p.Id == id);

        /// <summary>
        /// Representa el filtrado de productos por SKU
        /// </summary>
        /// <param name="sku">Sku a filtrar</param>
        /// <returns>Specification de filtrado de productos por Sku</returns>
        public static Specification<Producto> IdentificadoPor(string sku) =>
            new ExprSpecification<Producto>(p => p.Sku.Equals(sku));
    }
}
