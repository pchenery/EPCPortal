using EPCPortalWeb.Models;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading.Tasks;

namespace EPCPortalTesting.EPCPortalWeb.IntegrationTests
{
    [TestFixture]
    public class PostcodeSearchTests
    {
        [Test]
        public async Task GetListOfAddresses_WhenValidPostcode_ListOfAddressesReturnedHasCountGreaterOrEqualToOne()
        {
            const string validPostcode = "E6 1BJ";
            var dataHandlerModel = new DataHandlerModel();

            var listOfAddresses = await dataHandlerModel.GetListOfAddresses(validPostcode);

            listOfAddresses.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Test]
        public async Task GetListOfAddresses_WhenInvalidPostcode_NoAddressesAreReturned()
        {
            const string validPostcode = "invalid postcode";
            var dataHandlerModel = new DataHandlerModel();

            var listOfAddresses = await dataHandlerModel.GetListOfAddresses(validPostcode);

            listOfAddresses.Should().BeEmpty();
        }
    }
}
