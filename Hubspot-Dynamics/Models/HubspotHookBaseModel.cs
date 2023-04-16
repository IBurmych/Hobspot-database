using Hubspot_Dynamics.Enums;

namespace Hubspot_Dynamics.Models
{
    public class HubspotHookBaseModel
    {
        public long objectId { get; set; }
        public string subscriptionType { get; set; }
    }
}
