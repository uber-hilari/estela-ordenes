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
    public class LineaOrdenConfig : IEntityTypeConfiguration<LineaOrden>
    {
        public void Configure(EntityTypeBuilder<LineaOrden> builder)
        {
            builder.EntityConfig();
            builder.Property(c => c.Cantidad)
                .HasPrecision(18, 2);
            builder.Property(c => c.PrecioUnitario)
                .HasPrecision(18, 4);
            builder.Property(c => c.SubTotal)
                .HasPrecision(18, 4);
        }
    }
}
