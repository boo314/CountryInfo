namespace CountriesProcessUnit.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FlagBase64 { get; set; }
        public string Description { get; set; }
        public long Population { get; set; }
        public CapitalModel Capital { get; set; }
    }
}