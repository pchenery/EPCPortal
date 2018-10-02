using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPCPortalWeb.Models
{
    public class DataHandlerModel
    {
        //class that takes parameters as a input and outputs a list of addresses for the user 
        public string Postcode { get; set; }
        public int HouseNumber { get; set; }

        public string APIAddress { get; set; }


        public IEnumerable<string> FilterAddressesByHouseNumber(int houseNumber, List<string> listOfAPIAddresses)
        {
            return listOfAPIAddresses.Where(t => t.Contains(houseNumber.ToString()));
        }
    }

}
