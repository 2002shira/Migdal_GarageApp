using Microsoft.Extensions.Logging;
using MigdalApi.BusinessLogic.Interfaces;
using MigdalApi.Models.Basic;
using MigdalApi.Models.GovApi;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace MigdalApi.BusinessLogic
{
    public class GovApiBL : IGovApiBL
    {
        private readonly string serviceUrl = "https://data.gov.il/api/3/action/datastore_search?resource_id=bb68386a-a331-4bbc-b668-bba2766d517d&limit=5";
        public async Task<ServerResponse> GetGaragesAsync()
        {
            ServerResponse serverResponse = new ServerResponse();
            try
            {
                List<GovGarageRecord> govGaragesList = new List<GovGarageRecord>();
                var govApiRes = await GetAsync(serviceUrl);

                var apiResponse = JsonSerializer.Deserialize<GovApiResponse>(govApiRes);

                if (apiResponse == null || apiResponse.result == null || apiResponse.result.records == null)
                {
                    return serverResponse;
                }

                serverResponse.Data = apiResponse.result.records;
            }
            catch (Exception ex)
            {
                serverResponse.SetError(500, "failed in getting data from gov api");
            }      
            
            return serverResponse;
       
        }

        public async Task<string> GetAsync(string serviceUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var getResult = await client.GetAsync(serviceUrl);

                    if (getResult.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }

                    string resultContent = await getResult.Content.ReadAsStringAsync();
                    return resultContent;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
