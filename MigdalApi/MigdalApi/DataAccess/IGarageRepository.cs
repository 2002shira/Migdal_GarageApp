using MigdalApi.Models;

namespace MigdalApi.Data
{
    public interface IGarageRepository
    {
        Task<List<Garage>> GetAllAsync();
        Task AddRangeAsync(IEnumerable<Garage> garages);
        Task<bool> ExistsAsync(int misparMosach, int codMiktzoa);
        Task SaveChangesAsync();
    }
}
