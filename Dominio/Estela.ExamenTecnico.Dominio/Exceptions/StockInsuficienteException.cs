using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Exceptions
{
    public class StockInsuficienteException(string sku): BaseException(40610, $"El {sku} no tiene stock suficiente")
    {
    }
}
