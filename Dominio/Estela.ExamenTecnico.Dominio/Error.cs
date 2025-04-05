using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio
{
    public class Error(int codigo, string mensaje)
    {
        public int Codigo { get; } = codigo;
        public string Mensaje { get; } = mensaje;
    }
}
