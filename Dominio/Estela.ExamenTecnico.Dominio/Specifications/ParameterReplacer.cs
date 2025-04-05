using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Estela.ExamenTecnico.Dominio.Specifications
{
    internal class ParameterReplacer: ExpressionVisitor
    {
        private readonly ParameterExpression _paramExpr;

        public ParameterReplacer(ParameterExpression paramExpr)
        {
            _paramExpr = paramExpr;
        }

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_paramExpr);
    }
}
