using System.ComponentModel.DataAnnotations;

namespace CountriesProcessUnit.ViewModels
{
    public class CountryViewModel
    {
        [Display(Name = "County name")]
        public string CountryName { get; set; }

        [Display(Name = "County description")]
        public string CountryDescription { get; set; }

        [Display(Name = "County population")]
        public long CountryPopulation { get; set; }

        [Display(Name = "Capital name")]
        public string CapitalName { get; set; }

        [Display(Name = "Capital description")]
        public string CapitalDescription { get; set; }

        [Display(Name = "Capital population")]
        public long CapitalPopulation { get; set; }

        [Display(Name = "Flag")]
        public string FlagBase64 { get; set; }
    }
}