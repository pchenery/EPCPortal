using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EPCData.API
{
    public class RequestParameters
    {
        private const string PostcodeParameterName = "postcode";
        private const string SizeParameterName = "size";
        private const int SizeMinValue = 1;
        private const int SizeMaxValue = 100;

        public SingleRequestParameter Postcode { get; }
        public SingleRequestParameter Size { get; }
        public IEnumerable<SingleRequestParameter> OptionalParameters { get; }

        public RequestParameters(
            string postcode, 
            int size, 
            IEnumerable<SingleRequestParameter> optionalParameters = null)
        {
            Postcode = GetPostcodeParameter(postcode);
            Size = GetSizeParameter(size);
            OptionalParameters = optionalParameters ?? new List<SingleRequestParameter>();
        }

        private static SingleRequestParameter GetPostcodeParameter(string postcode)
        {
            if (string.IsNullOrEmpty(postcode) || string.IsNullOrWhiteSpace(postcode))
            {
                throw new ArgumentException("Postcode cannot be null, empty or whitespace.");
            }

            var postcodeValue = Regex.Replace(postcode, @"\s+", "");

            return new SingleRequestParameter(PostcodeParameterName, postcodeValue);
        }
        
        private static SingleRequestParameter GetSizeParameter(int size)
        {
            if (size < SizeMinValue || size > SizeMaxValue)
            {
                throw new ArgumentException($"Provided size value of {size} was outside the accepted range of {SizeMinValue} and {SizeMaxValue}.");
            }

            return new SingleRequestParameter(SizeParameterName, size.ToString());
        }
    }
}
