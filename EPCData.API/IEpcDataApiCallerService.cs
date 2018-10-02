using System.Threading.Tasks;

namespace EPCData.API
{
    public interface IEpcDataApiCallerService
    {
        Task<T> ExecuteRequestAsync<T>(RequestParameters requestParameters);
    }
}
