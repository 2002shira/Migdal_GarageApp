using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MigdalApi.BusinessLogic.Interfaces;
using MigdalApi.Models;
using MigdalApi.Models.Basic;

namespace MigdalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GaragesController : ControllerBase
    {
        private readonly IGarageBL grageService;

        public GaragesController(IGarageBL service)
        {
            grageService = service;
        }

        [HttpPost]
        [Route("GetAllGarageFromGovApi")]
        public async Task<ActionResult<ServerResponse>> GetAllGarageFromGovApi()
        {
            ServerResponse serverResponse = new ServerResponse();

            try
            {
                serverResponse = await grageService.LoadAllGarageFromGovApiAsync();

                return Ok(serverResponse);

            }
            catch (Exception ex)
            {
                serverResponse.SetError(500);
                return Ok(serverResponse);
            }
        }

        [HttpPost]
        [Route("LoadAllGarageFromDb")]
        public async Task<ActionResult<ServerResponse>> LoadAllGarageFromDb()
        {
            ServerResponse serverResponse = new ServerResponse();

            try
            {
                serverResponse = await grageService.LoadAllGarageFromDbAsync();

                return Ok(serverResponse);

            }
            catch (Exception ex)
            {
                serverResponse.SetError(500);
                return Ok(serverResponse);
            }
        }

        // POST api/garages
        [HttpPost]
        [Route("AddGarages")]
        public async Task<ActionResult<ServerResponse>> AddGarages(AddGaragesRequest request)
        {
            ServerResponse serverResponse = new ServerResponse();

            try
            {
                serverResponse = await grageService.AddGarageToDbAsync(request);

                return Ok(serverResponse);

            }
            catch (Exception ex)
            {
                serverResponse.SetError(500);
                return Ok(serverResponse);
            }
        }
    }
}
