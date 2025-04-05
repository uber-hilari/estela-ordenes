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
    public class OrdenConfig : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.EntityConfig();
            builder.Property(c => c.Total)
                .HasPrecision(18, 4);
            builder.HasMany(c => c.Lineas)
                .WithOne()
                .HasForeignKey("IdOrden");
        }
    }
}
