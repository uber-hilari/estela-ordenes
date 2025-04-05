using Estela.ExamenTecnico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Specifications
{
    public class ExprSpecification<T>(Expression<Func<T, bool>> expression)
        : Specification<T> where T : BaseEntity
    {
        public override Expression<Func<T, bool>> ToExpression() => expression;
    }
}
