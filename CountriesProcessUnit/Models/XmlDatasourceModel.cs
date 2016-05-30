using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesProcessUnit.Models
{
    public class XmlDatasourceModel<TEntity>
    {
        public TEntity[] DataList { get; set; }
    }
}
