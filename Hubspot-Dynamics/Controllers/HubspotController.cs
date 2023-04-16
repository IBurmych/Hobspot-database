using Azure;
using Hubspot_Dynamics.Models;
using Hubspot_Dynamics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hubspot_Dynamics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubspotController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public HubspotController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateContact([FromBody]ContactHookModel model)
        {
            await _contactsService.AddContactAsync(model.objectId);

            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> CreateDelete([FromBody] ContactHookModel model)
        {
            await _contactsService.DeleteContact(model.objectId);

            return Ok();
        }
        // todo: another endpoints. For edit etc.
    }
}
