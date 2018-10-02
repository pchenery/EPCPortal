using System.Linq;
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

            var listOfProperties = await dataHandlerModel.GetListOfProperties(validPostcode);

            listOfProperties.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Test]
        public async Task GetListOfAddresses_WhenValidPostcode_EveryPropertyHasAnAddressValue()
        {
            const string validPostcode = "E6 1BJ";
            var dataHandlerModel = new DataHandlerModel();

            var listOfProperties = await dataHandlerModel.GetListOfProperties(validPostcode);

            var propertiesCount = listOfProperties.Count();
            var addressCount = listOfProperties.Count(p => !string.IsNullOrEmpty(p.Address));

            propertiesCount.Should().Be(addressCount);
        }

        [Test]
        public async Task GetListOfAddresses_WhenInvalidPostcode_NoAddressesAreReturned()
        {
            const string validPostcode = "invalid postcode";
            var dataHandlerModel = new DataHandlerModel();

            var listOfAddresses = await dataHandlerModel.GetListOfProperties(validPostcode);

            listOfAddresses.Should().BeEmpty();
        }
    }
}
