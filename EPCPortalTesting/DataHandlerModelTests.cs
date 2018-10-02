using EPCPortalWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EPCPortalTesting
{
    [TestClass]
    public class DataHandlerModelTests
    {
        private readonly DataHandlerModel dataHandlerModel = new DataHandlerModel();

        private readonly List<string> propertyAddresses = new List<string>
        {
                "1 fake street",
                "2 fake street",
                "3 fake street",
                "4 fake street",
                "5 fake street"
            };

        [TestMethod]
        public void FilterAddressesByHouseNumber_WhenHouseNumberInListOfAddresses_FilteredListIsNotNull()
        {
            var newlist = dataHandlerModel.FilterAddressesByHouseNumber(3, propertyAddresses);
            foreach (var item in newlist)
            {
                Assert.AreEqual(item, "3 fake street");
            }
        }
    }
}
