using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CountryInfo.App_Start
{
    public class PageConfig
    {
        public static string XmlDatasourcePath
        {
            get 
            {
                var result = ConfigurationManager.AppSettings["XmlFilePath"];
                return result;
            }
        }
    }
}