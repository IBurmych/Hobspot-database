using AutoMapper;
using Hubspot_Dynamics.Entities;
using Hubspot_Dynamics.Models;
using Hubspot_Dynamics.Repositories;

namespace Hubspot_Dynamics.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IHubspotApiRepository _hubspotApiRepository;
        private readonly IMapper _mapper;

        public ContactsService(IContactsRepository contactsRepository, IHubspotApiRepository hubspotApiRepository, IMapper mapper)
        {
            _hubspotApiRepository = hubspotApiRepository;
            _mapper = mapper;
            _contactsRepository = contactsRepository;
        }
        public async Task AddContactAsync(long contactId)
        {
            ContactModel model = await _hubspotApiRepository.GetContactByIdAsync(contactId);
            if (model == null) return;

            ContactEntity entity = _mapper.Map<ContactEntity>(model);

            await _contactsRepository.AddContactAsync(entity);
            return;
        }
        public async Task<int> DeleteContact(long contactId)
        {
            return await _contactsRepository.RemoveContact(contactId);
        }
    }
}
