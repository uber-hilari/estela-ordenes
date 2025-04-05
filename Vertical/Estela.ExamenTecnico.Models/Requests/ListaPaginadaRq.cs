using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Models.Requests
{
    public record ListaPaginadaRq
    {
        public int PaginaActual { get; set; } = 1;
        public int FilasPorPagina { get; set; } = 20;
    }
}
