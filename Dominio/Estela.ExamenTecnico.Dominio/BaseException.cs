﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estela.ExamenTecnico.Dominio
{
    public class BaseException : Exception
    {
        public BaseException()
        {
            Codigo = 50000;
        }

        public BaseException(string mensaje) : base(mensaje)
        {
            Codigo = 50000;
        }

        public BaseException(int codigo, string mensaje) : base(mensaje)
        {
            Codigo = codigo;
        }

        public int Codigo { get; protected set; }
        public bool GrabarData { get; set; } = false;

        public virtual IEnumerable<Error> GetErrors()
        {
            return new Error[] { GetError() };
        }

        public virtual Error GetError()
        {
            return new Error(Codigo, Message);
        }
    }
}
