using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesProcessUnit.Infrastructure.Exceptions
{
    public class CantAddEntityException : Exception
    {
        public CantAddEntityException() : base("Cannot add entity to datasource.") { }
        public CantAddEntityException(string message) : base(message) { }
        public CantAddEntityException(string message, Exception innerException) : base(message, innerException) { }
    }
}
