using Hubspot_Dynamics.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hubspot_Dynamics.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly Context _db;

        public ContactsRepository(Context db)
        {
            _db = db;
        }
        public async Task<int> AddContactAsync(ContactEntity contact)
        {
            await _db.Contacts.AddAsync(contact);
            return await _db.SaveChangesAsync();
        }
        public async Task<int> RemoveContact(long contactId)
        {
            ContactEntity? contact = await _db.Contacts.FirstOrDefaultAsync(x => x.Id == contactId);
            if (contact == null) return 0;

            _db.Contacts.Remove(contact);
            return await _db.SaveChangesAsync();
        }
    }
}
