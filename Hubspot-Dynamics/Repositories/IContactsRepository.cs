using Hubspot_Dynamics.Entities;

namespace Hubspot_Dynamics.Repositories
{
    public interface IContactsRepository
    {
        Task<int> AddContactAsync(ContactEntity contact);
        Task<int> RemoveContact(long contactId);
    }
}
