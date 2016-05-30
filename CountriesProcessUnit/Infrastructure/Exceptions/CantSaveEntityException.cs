using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesProcessUnit.Infrastructure.Exceptions
{
    public class CantSaveEntityException : Exception
    {
        public CantSaveEntityException() : base("Cannot save entity to datasource.") { }
        public CantSaveEntityException(string message) : base(message) { }
        public CantSaveEntityException(string message, Exception innerException) : base(message, innerException) { }
    }
}
