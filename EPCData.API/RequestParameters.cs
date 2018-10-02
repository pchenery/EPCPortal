using System;
using System.Text.RegularExpressions;

namespace EPCData.API
{
    public class RequestParameters
    {
        private const string POSTCODE_PARAMETER_NAME = "postcode";
        private const string SIZE_PARAMETER_NAME = "size";
        private const int SIZE_MIN_VALUE = 1;
        private const int SIZE_MAX_VALUE = 100;

        public SingleRequestParameter Postcode { get; }
        public SingleRequestParameter Size { get; }

        public RequestParameters(string postcode, int size)
        {
            Postcode = GetPostcodeParameter(postcode);
            Size = GetSizeParameter(size);
        }

        private static SingleRequestParameter GetPostcodeParameter(string postcode)
        {
            if (string.IsNullOrEmpty(postcode) || string.IsNullOrWhiteSpace(postcode))
            {
                throw new ArgumentException("Postcode cannot be null, empty or whitespace.");
            }

            var postcodeValue = Regex.Replace(postcode, @"\s+", "");

            return new SingleRequestParameter(POSTCODE_PARAMETER_NAME, postcodeValue);
        }
        
        private static SingleRequestParameter GetSizeParameter(int size)
        {
            if (size < SIZE_MIN_VALUE || size > SIZE_MAX_VALUE)
            {
                throw new ArgumentException($"Provided size value of {size} was outside the accepted range of {SIZE_MIN_VALUE} and {SIZE_MAX_VALUE}.");
            }

            return new SingleRequestParameter(SIZE_PARAMETER_NAME, size.ToString());
        }
    }
}
