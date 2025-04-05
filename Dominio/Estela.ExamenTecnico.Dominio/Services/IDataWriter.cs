using Estela.ExamenTecnico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Services
{
    public interface IDataWriter
    {
        /// <summary>
        /// Agrega una entidad al repositorio
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad</typeparam>
        /// <param name="entity">Entidad a agregar en el repositorio</param>
        /// <returns></returns>
        Task Agregar<TEntity>(TEntity entity) where TEntity : BaseEntity;
        /// <summary>
        /// Fuerza el almacenamiento en el repositorio. Normalmente se usa para obtener el ID generado por el repositorio
        /// </summary>
        /// <returns></returns>
        Task Grabar();
    }
}
