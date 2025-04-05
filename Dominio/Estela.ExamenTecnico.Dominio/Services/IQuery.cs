using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Services
{
    public interface IQuery<TResult>
    {
        /// <summary>
        /// Ejecuta la consulta en el repositorio
        /// </summary>
        /// <returns>Resultado de la consulta</returns>
        Task<TResult> Execute();
    }
}
