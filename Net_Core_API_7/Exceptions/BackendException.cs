using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Exceptions
{

    public class BackendException : Exception
    {
        public BackendException()
        {

        }
        public BackendException(string message)
            : base(message)
        {

        }
        public BackendException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}


