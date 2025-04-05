using Estela.ExamenTecnico.Aplicacion.Commands.Productos;
using Estela.ExamenTecnico.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Validations.Productos
{
    public class CrearProductoValidator: AbstractValidator<CrearProductoCommand>, IValidator<CrearProductoCommand>
    {
        public CrearProductoValidator()
        {
            RuleFor(c => c.Data)
                .NotNull()
                .ValidateData();
        }
    }

    static class CrearProductoValidatorExtensions
    {
        public static IRuleBuilderOptions<CrearProductoCommand, CrearProductoRq> ValidateData(this IRuleBuilderOptions<CrearProductoCommand, CrearProductoRq> rule)
        {
            rule.ChildRules(d =>
            {
                d.RuleFor(c => c.Sku)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("El 'Sku' es obligatorio");
                d.RuleFor(c => c.Nombre)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("El 'Nombre' es obligatorio");
                d.RuleFor(c => c.Precio)
                    .Must(p => p > 0)
                    .WithMessage("El 'precio' debe ser positivo");
                d.RuleFor(c => c.Stock)
                    .Must(p => p > 0)
                    .WithMessage("El 'stock' debe ser positivo");
            });
            return rule;
        }
    }
}
