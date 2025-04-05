using Estela.ExamenTecnico.DataAccess.Services;
using Estela.ExamenTecnico.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.DataAccess
{
    public static class DataAccessExtensiones
    {
        public static MediatRServiceConfiguration AgregarDataAccess(this MediatRServiceConfiguration config)
        {
            config.AddOpenBehavior(typeof(SessionPipelineBehavior<,>));
            return config;
        }

        public static IServiceCollection AgregarDataAccess(this IServiceCollection services)
        {
            services.AddDbContextFactory<AppDbContext>((sp, opts) =>
            {
                var cfg = sp.GetService<IConfiguration>() ?? throw new InvalidOperationException("No se ha configurado el Servicio 'Configuration'");
                var cn = cfg.GetConnectionString("DbOrdenes");
                opts.UseLazyLoadingProxies();
                opts.UseSqlServer(cn);
                opts.AddInterceptors(
                    sp.GetRequiredService<NuevaEntidadInterceptor>(), 
                    sp.GetRequiredService<SoftDeleteInterceptor>(), 
                    sp.GetRequiredService<CambioEntidadInterceptor>()
                );
            });
            services.AddSingleton<NuevaEntidadInterceptor>();
            services.AddSingleton<SoftDeleteInterceptor>();
            services.AddSingleton<CambioEntidadInterceptor>();
            services.AddScoped<IDataWriter, DataWriter>();
            services.AddScoped<IDataReader, DataReader>();
            services.AddTransient<IUltimoNumeroOrdenQuery, UltimoNumeroOrdenQuery>();
            return services;
        }
    }
}
