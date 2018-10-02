using RestSharp;
using System;
using System.Threading.Tasks;

namespace EPCData.API
{
    public class EpcDataApiCallerService : IEpcDataApiCallerService
    {
        private const string EpcDataApiUrl = "https://dceas-user-site-staging.cloudapps.digital/api/epc";
        private readonly IRestClient client;

        public EpcDataApiCallerService()
        {
            client = new RestClient { BaseUrl = new Uri(EpcDataApiUrl) };
        }

        public async Task<T> ExecuteRequestAsync<T>(RequestParameters requestParameters)
        {
            var request = new RestRequest();
            request.AddParameter(requestParameters.Postcode.Name, requestParameters.Postcode.Value);
            request.AddParameter(requestParameters.Size.Name, requestParameters.Size.Value);

            var restResponse = await client.ExecuteTaskAsync<T>(request);
            
            return restResponse.Data;
        }
    }
}
