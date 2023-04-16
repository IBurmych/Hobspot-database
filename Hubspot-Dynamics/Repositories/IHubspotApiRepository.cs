using Hubspot_Dynamics.Models;

namespace Hubspot_Dynamics.Repositories
{
    public interface IHubspotApiRepository
    {
        public Task<ContactModel> GetContactByIdAsync(long id);
    }
}
