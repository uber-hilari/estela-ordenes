using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio
{
    public class PagedList<TItem> where TItem : class
    {
        public int TotalPaginas { get; set; }
        public int TotalRegistros { get; set; }
        public IEnumerable<TItem> Items { get; set; } = [];

        /// <summary>
        /// Crea una copia del listado actual, realizando el mapeo de items especificado por el Delegate proporcionado
        /// </summary>
        /// <typeparam name="TResult">Tipo de items resultante</typeparam>
        /// <param name="map">Delegate para realizar el cambio</param>
        /// <returns>Listado con el tipo resultante</returns>
        public PagedList<TResult> Map<TResult>(Func<TItem, TResult> map) where TResult : class
        {
            return new PagedList<TResult>
            {
                Items = Items.Select(map).ToArray(),
                TotalPaginas = TotalPaginas,
                TotalRegistros = TotalRegistros
            };
        }

        public static PagedList<TItem> Create(IEnumerable<TItem> items, int pageSize, int count)
        {
            return new PagedList<TItem>
            {
                TotalPaginas = (int)Math.Ceiling(count / (decimal)pageSize),
                TotalRegistros = count,
                Items = items
            };
        }
    }
}
