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

        private const string ValidPostcode = "NW5 2TA";
        private const int ValidSize = 1;

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
            var parameters = new RequestParameters(postcode, ValidSize);

            var data = await service.ExecuteRequestAsync<TestDataModel>(parameters);

            data.Should().BeNullOrEmpty();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeAndSize_ThenDataReturnedIsNotNull()
        {
            var parameters = new RequestParameters(ValidPostcode, ValidSize);

            var data = await service.ExecuteRequestAsync<TestDataModel>(parameters);

            data.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeAndSize_ThenPropertyThatDoesNotMapToResponseIsNull()
        {
            var parameters = new RequestParameters(ValidPostcode, ValidSize);

            var data = await service.ExecuteRequestAsync<TestDataModel>(parameters);

            data.ElementAt(0).PropertyNotFoundInResponse.Should().BeNull();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeAndSize_ThenPropertyThatMapsToResponseIsNotNull()
        {
            var parameters = new RequestParameters(ValidPostcode, ValidSize);

            var data = await service.ExecuteRequestAsync<TestDataModel>(parameters);

            data.ElementAt(0).Postcode.Should().Be(ValidPostcode);
        }
    }
}
