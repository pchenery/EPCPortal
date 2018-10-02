using EPCData.API;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace EPCPortalTesting.EPCData.API.UnitTests
{
    [TestFixture]
    public class RequestParametersTests
    {
        [TestCase("")]
        [TestCase(null)]
        [TestCase("  ")]
        public void CreateNew_WhenPostcodeEmptyNullOrWhitespace_ThenExceptionThrown(string postcodeValue)
        {
            const int sizeValue = 1;

            Assert.Throws<ArgumentException>(() =>
            {
                var requestParameters = new RequestParameters(postcodeValue, sizeValue);
            });
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(101)]
        public void CreateNew_WhenSizeNotBetween1And100_ThenExceptionThrown(int sizeValue)
        {
            const string postcodeValue = "postcode";

            Assert.Throws<ArgumentException>(() =>
            {
                var requestParameters = new RequestParameters(postcodeValue, sizeValue);
            });
        }

        [Test]
        public void CreateNew_WhenPostcodeProvidedAndSizeBetween1And100_ThenNoExceptionThrown()
        {
            const string postcodeValue = "postcode";
            const int sizeValue = 1;

            Assert.DoesNotThrow(() =>
            {
                var requestParameters = new RequestParameters(postcodeValue, sizeValue);
            });
        }

        [TestCase("ABC 123")]
        [TestCase(" ABC123")]
        [TestCase("ABC123 ")]
        public void CreateNew_WhenPostcodeStringContainsSpaces_ThenSpaceIsRemovedFromPostcodeValue(string postcode)
        {
            const string expectedPostcodeValue = "ABC123";
            const int sizeValue = 1;

            var requestParameters = new RequestParameters(postcode, sizeValue);

            requestParameters.Postcode.Value.Should().Be(expectedPostcodeValue);
        }
    }
}
