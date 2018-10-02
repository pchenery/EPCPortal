using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPCData.API
{
    public interface IEpcDataApiCallerService
    {
        Task<IEnumerable<T>> ExecuteRequestAsync<T>(RequestParameters requestParameters);
    }
}
