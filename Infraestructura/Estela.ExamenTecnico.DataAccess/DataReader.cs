using Estela.ExamenTecnico.Dominio;
using Estela.ExamenTecnico.Dominio.Entities;
using Estela.ExamenTecnico.Dominio.Exceptions;
using Estela.ExamenTecnico.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.DataAccess
{
    public class DataReader(IServiceProvider serviceProvider, AppDbContext dbContext) 
        : IDataReader
    {
        public Task<T> Get<T>(Guid id) where T : BaseEntity =>
            Get<T>(c => c.Id == id);

        public async Task<T> Get<T>(Expression<Func<T, bool>> expression) where T: BaseEntity
        {
            var entity = await GetOrNull(expression);
            if (entity == null)
                throw new NotFoundEntityException(typeof(T).Name);
            return entity;
        }

        public Task<T> GetDeleted<T>(Guid id) where T : BaseEntity =>
            GetDeleted<T>(c => c.Id == id && c.Eliminado == true);

        public async Task<T> GetDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            IQueryable<T> qry = dbContext.Set<T>().IgnoreQueryFilters();
            if (expression != null)
                qry = qry.Where(expression);
            return await qry.FirstOrDefaultAsync() ?? throw new NotFoundEntityException(typeof(T).Name);
        }

        public Task<T?> GetOrNull<T>(Guid id) where T : BaseEntity =>
            GetOrNull<T>(c => c.Id == id);

        public async Task<T?> GetOrNull<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            IQueryable<T> qry = dbContext.Set<T>();
            if (expression != null)
                qry = qry.Where(expression);
            return await qry.FirstOrDefaultAsync();
        }

        public TQuery GetQuery<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            return serviceProvider.GetService<TQuery>() ?? throw new NotImplementedException($"No se ha implementado '{typeof(TQuery).Name}'");
        }

        public Task<PagedList<T>> GetPagedList<T>(int paginaActual, int filasPorPagina) where T : BaseEntity =>
            GetPagedList<T>(null, paginaActual, filasPorPagina);

        public async Task<PagedList<T>> GetPagedList<T>(Expression<Func<T, bool>>? expression, int paginaActual, int filasPorPagina) where T : BaseEntity
        {
            IQueryable<T> qry = dbContext.Set<T>();
            if (expression != null)
                qry = qry.Where(expression);
            var total = await qry.CountAsync();
            var skip = (paginaActual - 1) * filasPorPagina;
            return PagedList<T>.Create(await qry.Skip(skip).Take(filasPorPagina).ToArrayAsync(), filasPorPagina, total);
        }

        public Task<IEnumerable<T>> GetList<T>() where T : BaseEntity =>
            GetList<T>(null);

        public async Task<IEnumerable<T>> GetList<T>(Expression<Func<T, bool>>? expression) where T : BaseEntity
        {
            IQueryable<T> qry = dbContext.Set<T>();
            if (expression != null)
                qry = qry.Where(expression);
            return await qry.ToArrayAsync();
        }
    }
}
