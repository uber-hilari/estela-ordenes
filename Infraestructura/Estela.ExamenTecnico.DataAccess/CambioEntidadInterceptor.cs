using Estela.ExamenTecnico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.DataAccess
{
    public class CambioEntidadInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }
            var entries = eventData
                .Context
                .ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified);
            foreach (var e in entries)
            {
                if (e.Property(c => c.Eliminado).IsModified)
                {
                    e.Property(c => c.EliminadoEn).CurrentValue = DateTime.UtcNow;
                    e.Property(c => c.EliminadoPor).CurrentValue = "System"; //TODO: Cambiar a usuario autenticado
                }
                else
                {
                    e.Property(c => c.ModificadoEn).CurrentValue = DateTime.UtcNow;
                    e.Property(c => c.ModificadoPor).CurrentValue = "System"; //TODO: Cambiar a usuario autenticado
                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
