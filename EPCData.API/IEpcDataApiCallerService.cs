using System.Collections.Generic;

namespace EPCData.API
{
    public interface IEpcDataApiCallerService<out T>
    {
        IEnumerable<T> ExecuteRequestAsync(RequestParameters requestParameters);
    }
}
