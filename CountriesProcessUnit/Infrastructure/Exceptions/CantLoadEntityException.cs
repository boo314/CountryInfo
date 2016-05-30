using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesProcessUnit.Infrastructure.Exceptions
{
    public class CantLoadEntityException : Exception
    {
        public CantLoadEntityException() : base("Cannot load entity to datasource.") { }
        public CantLoadEntityException(string message) : base(message) { }
        public CantLoadEntityException(string message, Exception innerException) : base(message, innerException) { }
    }
}
