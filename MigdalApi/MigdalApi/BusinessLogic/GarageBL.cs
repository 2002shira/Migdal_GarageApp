using System.Net.Http;
using System.Net.Http.Json;
using MigdalApi.BusinessLogic.Interfaces;
using MigdalApi.Data;
using MigdalApi.Models;
using MigdalApi.Models.Basic;

namespace MigdalApi.Services
{
    public class GarageBL : IGarageBL
    {
        private readonly IGarageRepository garageRepository;
        private readonly IGovApiBL govApi;

        public GarageBL(IGarageRepository repository, IGovApiBL govApi)
        {
            this.garageRepository = repository;
            this.govApi = govApi;
        }

        public async Task<ServerResponse> LoadAllGarageFromGovApiAsync()
        {
            ServerResponse serverResponse = new ServerResponse();
            var govGaragesRes = await govApi.GetGaragesAsync();

            if(govGaragesRes.IsError || govGaragesRes.Data == null)
            {
                serverResponse.SetError(500, "failed in getting data");
            }

            serverResponse.Data = govGaragesRes.Data;
            
            return serverResponse;
        }

        public async Task<ServerResponse> LoadAllGarageFromDbAsync()
        {
            ServerResponse serverResponse = new ServerResponse();
            try
            {
                var grageDbRecords = await garageRepository.GetAllAsync();
                serverResponse.Data = grageDbRecords;
            }
            catch (Exception)
            {
                serverResponse.SetError(500, "failed in getting data from DB");
            }

            return serverResponse;
        }

        public async Task<ServerResponse> AddGarageToDbAsync(AddGaragesRequest request)
        {
            ServerResponse serverResponse = new ServerResponse();
            try
            {
                var newGarages = new List<Garage>();

                if(request.GaragesList == null)
                {
                    return serverResponse;
                }

                foreach (var g in request.GaragesList)
                {
                    var exists = await garageRepository.ExistsAsync(g.MisparMosach, g.CodMiktzoa);
                    if (!exists)
                    {
                        newGarages.Add(g);
                    }
                }

                if (newGarages.Any())
                {
                    await garageRepository.AddRangeAsync(newGarages);
                    await garageRepository.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                serverResponse.SetError(500, "failed in AddGarageToDbAsync");
            }

            return serverResponse;
        }       
    }
}
