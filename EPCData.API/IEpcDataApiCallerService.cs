using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPCData.API
{
    public interface IEpcDataApiCallerService<T>
    {
        Task<IEnumerable<T>> ExecuteRequestAsync(RequestParameters requestParameters);
    }
}
