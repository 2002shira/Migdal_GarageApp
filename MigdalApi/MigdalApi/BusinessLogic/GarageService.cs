using System.Net.Http;
using System.Net.Http.Json;
using MigdalApi.Data;
using MigdalApi.Models;

namespace MigdalApi.Services
{
    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _repository;

        public GarageService(IGarageRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Garage>> LoadAllMosachFromApiAsync()
        {
            return new List<Garage>();
        }

        public Task<List<Garage>> LoadAllMosachFromDbAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<List<Garage>> AddMosachToDbAsync(IEnumerable<Garage> garages)
        {
            var newGarages = new List<Garage>();

            foreach (var g in garages)
            {
                var exists = await _repository.ExistsAsync(g.MisparMosach, g.CodMiktzoa);
                if (!exists)
                {
                    newGarages.Add(g);
                }
            }

            if (newGarages.Any())
            {
                await _repository.AddRangeAsync(newGarages);
                await _repository.SaveChangesAsync();
            }

            return newGarages;
        }
    }
}
