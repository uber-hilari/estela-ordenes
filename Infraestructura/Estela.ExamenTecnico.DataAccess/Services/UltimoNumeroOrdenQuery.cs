using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.DataAccess.Services
{
    public class UltimoNumeroOrdenQuery(
        AppDbContext dbContext
    ) : IUltimoNumeroOrdenQuery
    {
        public async Task<int> Execute()
        {
            try
            {
                return await dbContext.Set<Orden>().MaxAsync(c => c.Numero);
            }
            catch(InvalidOperationException)
            {
                return 0;
            }
        }
    }
}
