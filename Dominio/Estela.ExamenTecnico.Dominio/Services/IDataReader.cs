using Estela.ExamenTecnico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Services
{
    public interface IDataReader
    {
        /// <summary>
        /// Obtiene una entidad desde el repositorio de datos, se requiere el ID para identificarlo
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="id">Id de la entidad a buscar</param>
        /// <returns>Entidad existente en el repositorio</returns>
        /// <exception cref="NotFoundEntityException" />
        Task<T> Get<T>(Guid id) where T : BaseEntity;
        /// <summary>
        /// Obtiene una entidad desde el repositorio de datos, se requiere una expresión lógica para la busqueda
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="expression">Expresion lógica para la busqueda</param>
        /// <returns>Entidad existente en el repositorio</returns>
        /// <exception cref="NotFoundEntityException" />
        Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        /// <summary>
        /// Obtiene una entidad marcado como eliminado desde el repositorio de datos, se requiere el ID para identificarlo
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="id">Id de la entidad a buscar</param>
        /// <returns>Entidad existente en el repositorio</returns>
        /// <exception cref="NotFoundEntityException" />
        Task<T> GetDeleted<T>(Guid id) where T: BaseEntity;
        /// <summary>
        /// Obtiene una entidad marcado como eliminado desde el repositorio de datos, se requiere una expresión lógica para la busqueda
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="expression">Expresion lógica para la busqueda</param>
        /// <returns>Entidad existente en el repositorio</returns>
        /// <exception cref="NotFoundEntityException" />
        Task<T> GetDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        /// <summary>
        /// Obtiene una lista de todos los registros en el repositorio
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <returns>Lista de todos los registros</returns>
        Task<IEnumerable<T>> GetList<T>() where T : BaseEntity;
        /// <summary>
        /// Obtiene una lista filtrada por la expresión lógica de los registros en el repositorio
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="expression">Expresión lógica para filtrar los registros</param>
        /// <returns>Lista de todos los registros</returns>
        Task<IEnumerable<T>> GetList<T>(Expression<Func<T, bool>>? expression) where T : BaseEntity;
        /// <summary>
        /// Obtiene una entidad desde el repositorio de datos, se requiere el ID para identificarlo. Si no existe el registro devuelve NULL
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="id">Id de la entidad a buscar</param>
        /// <returns>Entidad existente en el repositorio</returns>
        Task<T?> GetOrNull<T>(Guid id) where T : BaseEntity;
        /// <summary>
        /// Obtiene una entidad desde el repositorio de datos, se requiere una expresión lógica para la busqueda. Si no existe el registro devuelve NULL
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="expression">Expresion lógica para la busqueda</param>
        /// <returns>Entidad existente en el repositorio</returns>
        Task<T?> GetOrNull<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        /// <summary>
        /// Obtiene una lista pagina de todos los registros en el repositorio
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="paginaActual">Página actual de consulta</param>
        /// <param name="filasPorPagina">Cantidad de filas para una página</param>
        /// <returns>Lista paginada de todos los registros</returns>
        Task<PagedList<T>> GetPagedList<T>(int paginaActual, int filasPorPagina) where T : BaseEntity;
        /// <summary>
        /// Obtiene una lista paginada filtrada por la expresión lógica de los registros en el repositorio
        /// </summary>
        /// <typeparam name="T">Tipo de Entidad</typeparam>
        /// <param name="expression">Expresión lógica para filtrar los registros</param>
        /// <param name="paginaActual">Página actual de consulta</param>
        /// <param name="filasPorPagina">Cantidad de filas para una página</param>
        /// <returns>Lista paginada de todos los registros</returns>
        Task<PagedList<T>> GetPagedList<T>(Expression<Func<T, bool>>? expression, int paginaActual, int filasPorPagina) where T: BaseEntity;
    }
}
