using Hubspot_Dynamics.Entities;

namespace Hubspot_Dynamics.Services
{
    public interface IContactsService
    {
        Task AddContactAsync(long contactId);
        Task<int> DeleteContact(long contactId);
    }
}
