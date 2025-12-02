using MigdalApi.Models;

namespace MigdalApi.Services
{
    public interface IGarageService
    {
        Task<List<Garage>> LoadAllMosachFromApiAsync();
        Task<List<Garage>> LoadAllMosachFromDbAsync();
        Task<List<Garage>> AddMosachToDbAsync(IEnumerable<Garage> garages);
    }
}
