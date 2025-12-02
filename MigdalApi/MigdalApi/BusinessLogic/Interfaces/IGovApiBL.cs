using MigdalApi.Models.Basic;
using MigdalApi.Models.GovApi;

namespace MigdalApi.BusinessLogic.Interfaces
{
    public interface IGovApiBL
    {
        Task<ServerResponse> GetGaragesAsync();
    }
}
