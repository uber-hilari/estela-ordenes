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
    public class NuevaEntidadInterceptor : SaveChangesInterceptor
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
                .Where(e => e.State == EntityState.Added);
            foreach (var e in entries)
            {
                e.Property(c => c.CreadoEn).CurrentValue = DateTime.UtcNow;
                e.Property(c => c.CreadoPor).CurrentValue = "System"; //TODO: Cambiar a usuario autenticado
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
