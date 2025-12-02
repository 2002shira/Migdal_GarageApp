using Microsoft.EntityFrameworkCore;
using MigdalApi.Models;

namespace MigdalApi.Data
{
    public class GarageRepository : IGarageRepository
    {
        private readonly AppDbContext context;

        public GarageRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Garage>> GetAllAsync()
        {
            return await context.Garages.AsNoTracking().ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Garage> garages)
        {
            await context.Garages.AddRangeAsync(garages);
        }

        public Task<bool> ExistsAsync(int misparMosach, int codMiktzoa)
        {
            return context.Garages.AnyAsync(g =>
                g.MisparMosach == misparMosach && g.CodMiktzoa == codMiktzoa);
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
