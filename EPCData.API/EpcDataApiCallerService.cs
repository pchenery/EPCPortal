using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPCData.API
{
    public class EpcDataApiCallerService : IEpcDataApiCallerService
    {
        private const string EPC_DATA_API_URL = "https://dceas-user-site-staging.cloudapps.digital/api/epc";
        private readonly IRestClient client;

        public EpcDataApiCallerService()
        {
            client = new RestClient
            {
                BaseUrl = new Uri(EPC_DATA_API_URL)
            };
        }

        public async Task<IEnumerable<T>> ExecuteRequestAsync<T>(RequestParameters requestParameters)
        {
            var request = GetRestRequest(requestParameters);
            var restResponse = await client.ExecuteTaskAsync<ResponseModel>(request);

            if (restResponse.Data == null)
            {
                return null;
            }

            var deserializeData = JsonConvert.DeserializeObject<IEnumerable<T>>(restResponse.Data.Rows);

            return deserializeData;
        }

        private static IRestRequest GetRestRequest(RequestParameters requestParameters)
        {
            var request = new RestRequest();
            request.AddParameter(requestParameters.Postcode.Name, requestParameters.Postcode.Value);
            request.AddParameter(requestParameters.Size.Name, requestParameters.Size.Value);

            return request;
        }
    }
}
