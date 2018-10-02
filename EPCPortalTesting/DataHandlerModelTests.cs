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
       
        [TestMethod]
        public void SearchForAddressByHouseNumber()
        {
            List<string> MockAPIReturn = new List<string>()
            {
                "1 fake street",
                "2 fake street",
                "3 fake street",
                "4 fake street",
                "5 fake street"
            };

            List<string> newlist = dataHandlerModel.FilterAddressesByHouseNumber(3, MockAPIReturn);

            Assert.IsNotNull(newlist);
        }
    }
}
