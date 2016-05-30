using CountriesProcessUnit.Infrastructure.Exceptions;
using CountriesProcessUnit.Infrastructure.Mapper;
using CountriesProcessUnit.Models;
using CountriesProcessUnit.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CountriesProcessUnit.Infrastructure.DAL
{
    public class CountriesXMLDatasource : XMLDatasourceAbstract<CountryModel>
    {
        private CountriesDataMapper mapper;
        public CountriesXMLDatasource(string dataFileLocation) : base(dataFileLocation)
        {
            mapper = new CountriesDataMapper();
        }

        public override bool Add(CountryViewModel viewModel)
        {
            var result = false;
            try
            {
                var entity = mapper.GetCountryModelFromCountryViewModel(viewModel);
                entity.Id = GetCountriesNextId();
                entity.Capital.Id = GetCapitalsNextId();
                var tempList = memory.ToList();
                tempList.Add(entity);
                memory = tempList;
                SaveFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CantAddEntityException("Cannot add entity to Xml file.", ex);
            }
            return result;
        }

        public override bool AddRange(IEnumerable<CountryViewModel> viewModel)
        {
            var result = false;
            try
            {
                var entities = mapper.GetCountryModelsFromCountryViewModels(viewModel);

                memory.ToList().AddRange(entities);
                SaveFile();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CantAddEntityException("Cannot add multiple entities to Xml file.", ex);
            }
            return result;
        }

        public override IEnumerable<CountryViewModel> GetAll()
        {
            var entities = LoadFile();
            var result = mapper.GetCountryViewModelsFromCountryModels(entities);
            return result;
        }

        public override CountryViewModel Get(Func<CountryModel, bool> condition)
        {
            CountryViewModel result = null;
            try
            {
                LoadFile();
                var entity = memory.FirstOrDefault(condition);
                result = mapper.GetCountryViewModelFromCountryModel(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #region Private methods
        private int GetCountriesLastId()
        {
            LoadFile();
            var result = memory.OrderBy(model => model.Id).LastOrDefault();
            if (result == null)
            {
                return 0;
            }
            return result.Id;
        }

        private int GetCountriesNextId()
        {
            var result = GetCountriesLastId() + 1;
            return result;
        }

        private int GetCapitalsLastId()
        {
            LoadFile();

            var result = memory.OrderBy(model => model.Capital.Id).LastOrDefault();
            if (result == null)
            {
                return 0;
            }
            return result.Id;
        }

        private int GetCapitalsNextId()
        {
            var result = GetCapitalsLastId() + 1;
            return result;
        }
        #endregion Private methods
    }
}