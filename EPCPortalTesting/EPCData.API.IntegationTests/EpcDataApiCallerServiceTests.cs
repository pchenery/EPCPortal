using System.Linq;
using System.Threading.Tasks;
using EPCData.API;
using FluentAssertions;
using NUnit.Framework;

namespace EPCPortalTesting.EPCData.API.IntegationTests
{
    [TestFixture]
    public class EpcDataApiCallerServiceTests
    {
        private class TestDataModel
        {
            public string Postcode { get; set; }
            public string PropertyNotFoundInResponse { get; set; }
        }

        private const string VALIDPOSTCODE = "NW5 2TA";
        private const int VALIDSIZE = 1;

        private IEpcDataApiCallerService service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            service = new EpcDataApiCallerService();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenInvalidPostcodeButValidSize_ThenDataReturnedIsNull()
        {
            const string postcode = "Invalid Postcode";
            var parameters = new RequestParameters(postcode, VALIDSIZE);

            var epcResponseResults = await service.ExecuteRequestAsync<TestDataModel>(parameters);

            epcResponseResults.Should().BeNullOrEmpty();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeAndSize_ThenDataReturnedIsNotNull()
        {
            var parameters = new RequestParameters(VALIDPOSTCODE, VALIDSIZE);

            var epcResponseResults = await service.ExecuteRequestAsync<TestDataModel>(parameters);

            epcResponseResults.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeAndSize_ThenPropertyThatDoesNotMapToResponseIsNull()
        {
            var parameters = new RequestParameters(VALIDPOSTCODE, VALIDSIZE);

            var epcResponseResults = await service.ExecuteRequestAsync<TestDataModel>(parameters);
            var firstResult = epcResponseResults.ElementAt(0);

            firstResult.PropertyNotFoundInResponse.Should().BeNull();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeAndSize_ThenPropertyThatMapsToResponseHasExpectedValue()
        {
            var parameters = new RequestParameters(VALIDPOSTCODE, VALIDSIZE);

            var epcResponseResults = await service.ExecuteRequestAsync<TestDataModel>(parameters);
            var firstResult = epcResponseResults.ElementAt(0);

            firstResult.Postcode.Should().Be(VALIDPOSTCODE);
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeWith10OrMoreAddressesAndSizeIs10_Then10ResultsShouldBeReturned()
        {
            const string postcode = "E6 1BJ";
            const int addressCount = 10;
            var parameters = new RequestParameters(postcode, addressCount);

            var epcResponseResults = await service.ExecuteRequestAsync<TestDataModel>(parameters);

            epcResponseResults.Should().HaveCount(addressCount);
        }
    }
}
