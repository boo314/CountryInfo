using CountriesProcessUnit.Models;
using CountriesProcessUnit.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CountriesProcessUnit.Infrastructure.Mapper
{
    public class CountriesDataMapper
    {
        public CountryModel GetCountryModelFromCountryViewModel(CountryViewModel viewModel)
        {
            var result = new CountryModel
            {
                Name = viewModel.CountryName,
                Description = viewModel.CountryDescription,
                Population = viewModel.CountryPopulation,
                Capital = new CapitalModel
                {
                    Name = viewModel.CapitalName,
                    Description = viewModel.CapitalDescription,
                    Population = viewModel.CapitalPopulation
                },
                FlagBase64 = viewModel.FlagBase64
            };
            return result;
        }

        public CountryViewModel GetCountryViewModelFromCountryModel(CountryModel model)
        {
            var result = new CountryViewModel
            {
                CountryName = model.Name,
                CountryDescription = model.Description,
                CountryPopulation = model.Population,
                CapitalName = model.Capital.Name,
                CapitalDescription = model.Capital.Description,
                CapitalPopulation = model.Capital.Population,
                FlagBase64 = model.FlagBase64
            };
            return result;
        }

        public IEnumerable<CountryModel> GetCountryModelsFromCountryViewModels(IEnumerable<CountryViewModel> viewModel)
        {
            var result = viewModel.Select(GetCountryModelFromCountryViewModel);
            return result;
        }

        public IEnumerable<CountryViewModel> GetCountryViewModelsFromCountryModels(IEnumerable<CountryModel> model)
        {
            var result = model.Select(GetCountryViewModelFromCountryModel);
            return result;
        }
    }
}