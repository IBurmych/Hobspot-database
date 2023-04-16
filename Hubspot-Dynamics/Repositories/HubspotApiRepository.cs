using Hubspot_Dynamics.Configurations;
using Hubspot_Dynamics.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Hubspot_Dynamics.Repositories
{
    public class HubspotApiRepository : IHubspotApiRepository
    {
        private const string contactsUrl = "/objects/contacts/";
        private HubspotConfiguration _configuration;
        public HubspotApiRepository(HubspotConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ContactModel> GetContactByIdAsync(long id)
        {
            try
            {
                string responseContent = await GetEntity(id, contactsUrl);
                var contact = JsonConvert.DeserializeObject<ContactResponseModel>(responseContent);

                return contact.properties;
            }
            catch (Exception)
            {
                // todo: logging
                return null;
            }
        }
        private async Task<string> GetEntity(long entityId, string entityUrl)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"{_configuration.BaseUrl}{entityUrl}{entityId}?hapikey={_configuration.ApiKey}";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(url);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
