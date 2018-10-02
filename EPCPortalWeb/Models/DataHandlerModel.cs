using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPCData.API;

namespace EPCPortalWeb.Models
{
    public class DataHandlerModel
    {
        //class that takes parameters as a input and outputs a list of addresses for the user 
        public string Postcode { get; set; }
        public int HouseNumber { get; set; }

        public async Task<IEnumerable<PropertyAddress>> GetListOfAddresses(string postcode)
        {
            var apiCaller = new EpcDataApiCallerService();
            var parameters = new RequestParameters(postcode, 100);
            var propertyAddresses = await apiCaller.ExecuteRequestAsync<PropertyAddress>(parameters);

            return propertyAddresses ?? new List<PropertyAddress>();
        }
        
        public IEnumerable<string> FilterAddressesByHouseNumber(int houseNumber, List<string> listOfAPIAddresses)
        {
            return listOfAPIAddresses.Where(t => t.Contains(houseNumber.ToString()));
        }
    }

}
