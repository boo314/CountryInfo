using CountriesProcessUnit.Infrastructure.DAL;
using CountriesProcessUnit.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CountriesProcessUnitTest
{
    [TestClass]
    public class DatasourceTest
    {
        private CountriesXMLDatasource datasource;

        [TestInitialize]
        public void Initialize()
        {
            var url = "./Test.xml";
            datasource = new CountriesXMLDatasource(url);
            var entities = new List<CountryModel>();
            entities.AddRange(new List<CountryModel>
            {
                new CountryModel{
                    Id = 1,
                    Name = "Poland",
                    Description = "Country in central Europ.",
                    FlagBase64 = "",
                    Population = 34567456,
                    Capital = new CapitalModel{
                        Id = 1,
                        Name = "Warsaw",
                        Description = "Grey city.",
                        Population = 1000000
                    }
                }
                , new CountryModel{
                    Id = 2,
                    Name = "France",
                    Description = "Guys of the white flags.",
                    FlagBase64 = "",
                    Population = 100786456,
                    Capital = new CapitalModel{
                        Id = 2,
                        Name = "Paris",
                        Description = "Multiculti city.",
                        Population = 2342341
                    }
                }
                , new CountryModel{
                    Id = 3,
                    Name = "England",
                    Description = "Guys of the tea.",
                    FlagBase64 = "",
                    Population = 60887556,
                    Capital = new CapitalModel{
                        Id = 3,
                        Name = "London",
                        Description = "Misty place.",
                        Population = 23444123
                    }
                }
            });
            datasource.AddRange(entities);
        }

        [TestMethod]
        public void GetAll()
        {
            var result = datasource.GetAll();
            var wooter = 0;
        }
    }
}