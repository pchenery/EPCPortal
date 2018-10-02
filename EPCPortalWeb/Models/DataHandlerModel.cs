using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPCPortalWeb.Models
{
    public class DataHandlerModel
    {
        public string Postcode { get; set; }
        public int HouseNumber { get; set; }

        public string APIAddress { get; set; }

        public List<string> FilterAddressesByHouseNumber(int houseNumber, List<string> listOfAPIAddresses)
        {
            List<string> newListOfFilteredAddresses = new List<string>();
            foreach (var address in listOfAPIAddresses)
            {
                if (address.Contains(houseNumber.ToString()))
                {
                    newListOfFilteredAddresses.Add(address);
                }
            }
            return newListOfFilteredAddresses;
        }
    }

}
