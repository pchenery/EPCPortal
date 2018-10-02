using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPCPortalWeb;
using EPCPortalWeb.Models;
using System.Collections.Generic;

namespace EPCPortalTesting
{
    [TestClass]
    public class DataHandlerModelTests
    {
        DataHandlerModel dataHandlerModel = new DataHandlerModel();

        List<string> MockAPIReturn = new List<string>()
            {
                "1 fake street",
                "2 fake street",
                "3 fake street",
                "4 fake street",
                "5 fake street"
            };

        List<string> GetListOfAddressesByPostcode(string postcode)
        {
            List<string> ListOfAddresses = new List<string>();
            //API Call
            ListOfAddresses = MockAPIReturn;
            return ListOfAddresses;
        }

        [TestMethod]
        public void SearchForAddressesByPostcode()
        {
            List<string> addresses = GetListOfAddressesByPostcode("RM96BF");
            Assert.IsNotNull(addresses);
        }

        [TestMethod]
        public void SearchForAddressesByPostcodeDoesNotReturnMoreThan10Results()
        {
            List<string> addresses = GetListOfAddressesByPostcode("RM96BF");
            bool fail = true;
            if (addresses.Count > 10)
            {
                fail = true;
            }
            else
            {
                fail = false;
            }
            Assert.IsFalse(fail);
        }

        [TestMethod]
        public void SearchForAddressByHouseNumber()
        {
            List<string> newlist = dataHandlerModel.FilterAddressesByHouseNumber(3, MockAPIReturn);

            Assert.IsNotNull(newlist);
        }

    }
}
