using Estela.ExamenTecnico.Aplicacion.Mapping;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion
{
    public static class AplicacionExtensions
    {
        public static MediatRServiceConfiguration AgregarAplicacion(this MediatRServiceConfiguration config)
        {
            config.AddOpenBehavior(typeof(ValidationPipeline<,>));
            config.RegisterServicesFromAssembly(typeof(AplicacionExtensions).Assembly);
            return config;
        }

        public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            services.AddValidatorsFromAssembly(typeof(AplicacionExtensions).Assembly);

            return services;
        }
    }
}
