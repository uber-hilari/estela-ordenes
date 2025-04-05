using Estela.ExamenTecnico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.DataAccess.Configurations
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.EntityConfig();
            builder.Property(c => c.Precio)
                .HasPrecision(18, 4);
            builder.Property(c => c.Stock)
                .HasPrecision(18, 4);
        }
    }
}
