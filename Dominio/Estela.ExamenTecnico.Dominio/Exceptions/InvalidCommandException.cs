using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio.Exceptions
{
    public class InvalidCommandException(IEnumerable<Error> errors): BaseException(40010, "Command Data Invalid")
    {
        public override IEnumerable<Error> GetErrors() => errors;
    }
}
