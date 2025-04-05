using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.DataAccess
{
    public class DataWriter(AppDbContext context) 
        : IDataWriter
    {
        public Task Agregar<TEntity>(TEntity entity) where TEntity : BaseEntity => Task.Run(() =>
        {
            context.Set<TEntity>().Add(entity);
        });

        public Task Grabar()
        {
            return context.SaveChangesAsync();
        }
    }
}
