using jwt_example.Models;

namespace jwt_example.Constants
{
    public class CountryConstants
    {
        public static List<CountryModel> Countries = new List<CountryModel>()
        {
            new CountryModel() {name = "Argentina"},
            new CountryModel() {name = "Italia"},
            new CountryModel() {name = "Uruguay"}        
        };
    }
}
