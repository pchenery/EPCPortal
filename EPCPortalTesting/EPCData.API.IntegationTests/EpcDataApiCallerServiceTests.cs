using System.Threading.Tasks;
using EPCData.API;
using FluentAssertions;
using NUnit.Framework;

namespace EPCPortalTesting.EPCData.API.IntegationTests
{
    [TestFixture]
    public class EpcDataApiCallerServiceTests
    {
        private IEpcDataApiCallerService service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            service = new EpcDataApiCallerService();
        }

        [Test]
        public async Task ExecuteRequestAsync_GivenValidPostcodeAndSizeValue_ThenDataReturnedIsNotNull()
        {
            const string postcode = "NW5 2TA";
            const int size = 1;
            var parameters = new RequestParameters(postcode, size);

            var data = await service.ExecuteRequestAsync<string>(parameters);

            data.Should().NotBeNullOrEmpty();
        }
    }
}
