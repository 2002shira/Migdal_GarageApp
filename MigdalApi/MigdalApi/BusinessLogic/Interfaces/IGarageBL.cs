using MigdalApi.Models;
using MigdalApi.Models.Basic;

namespace MigdalApi.BusinessLogic.Interfaces
{
    public interface IGarageBL
    {
        Task<ServerResponse> LoadAllGarageFromGovApiAsync();
        Task<ServerResponse> LoadAllGarageFromDbAsync();
        Task<ServerResponse> AddGarageToDbAsync(AddGaragesRequest garages);
    }
}
