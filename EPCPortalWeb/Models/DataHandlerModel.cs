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
        public IEnumerable<string> Address { get; set; }
        public IEnumerable<ReportDataModel> ReportDataModels { get; set; }

        public async Task GetListOfProperties()
        {
            var apiCaller = new EpcDataApiCallerService();
            var parameters = new RequestParameters(Postcode, 100);
            ReportDataModels = await apiCaller.ExecuteRequestAsync<ReportDataModel>(parameters);
            Address = ReportDataModels.Select(r => r.Address);
        }
        
        public IEnumerable<ReportDataModel> FilterAddressesByHouseNumber(int houseNumber)
        {
            return ReportDataModels.Where(t => t.Address.StartsWith(houseNumber.ToString()));
        }
    }

}
