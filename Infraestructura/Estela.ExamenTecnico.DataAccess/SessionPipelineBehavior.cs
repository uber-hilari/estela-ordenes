using Estela.ExamenTecnico.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.DataAccess
{
    public class SessionPipelineBehavior<TRequest, TResponse> (AppDbContext dbContext)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest: notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var transact = dbContext.Database.BeginTransaction();
            try
            {
                var result = await next();
                await dbContext.SaveChangesAsync();
                await transact.CommitAsync(cancellationToken);
                return result;
            }
            catch (BaseException ex)
            {
                if (ex.GrabarData)
                {
                    await dbContext.SaveChangesAsync();
                    await transact.CommitAsync(cancellationToken);
                    throw;
                }
                else
                {
                    await transact.RollbackAsync(cancellationToken);
                    throw;
                }
            }
            catch
            {
                await transact.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
