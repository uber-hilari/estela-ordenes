using Estela.ExamenTecnico.Aplicacion.Commands.Ordenes;
using Estela.ExamenTecnico.Aplicacion.Commands.Productos;
using Estela.ExamenTecnico.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Aplicacion.Validations.Ordenes
{
    public class CrearOrdenValidator : AbstractValidator<CrearOrdenCommand>, IValidator<CrearOrdenCommand>
    {
        public CrearOrdenValidator()
        {
            RuleFor(c => c.Data)
                .NotNull()
                .ValidateData();
        }
    }

    static class CrearOrdenValidatorExtensions
    {
        public static IRuleBuilderOptions<CrearOrdenCommand, CrearOrdenRq> ValidateData(this IRuleBuilderOptions<CrearOrdenCommand, CrearOrdenRq> rule)
        {
            rule.ChildRules(d =>
            {
                d.RuleFor(c => c.Glosa)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("La glosa es obligatoria");
                d.RuleFor(c => c.Lineas)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Es necesario agregar al menos una linea de la orden");
                d.RuleFor(c => c.Lineas)
                    .Validate();
            });
            return rule;
        }

        public static void Validate(this IRuleBuilderInitial<CrearOrdenRq, IEnumerable<LineaCrearOrdenRq>> rule)
        {
            rule.ForEach(r =>
            {
                r.ChildRules(d =>
                {
                    d.RuleFor(c => c.IdProducto)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("El IdProducto es obligatorio");
                    d.RuleFor(c => c.Cantidad)
                        .Must(v => v > 0)
                        .WithMessage("La cantidad debe ser positiva");
                });
            });
        }
    }
}
