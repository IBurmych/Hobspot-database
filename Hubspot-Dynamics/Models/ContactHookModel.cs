namespace Hubspot_Dynamics.Models
{
    public class ContactHookModel : HubspotHookBaseModel
    {
        public string changeSource { get; set; }
        public long eventId { get; set; }
        public long subscriptionId { get; set; }
        public long portalId { get; set; }
        public long appId { get; set; }
        public long occurredAt { get; set; }
        public long attemptNumber { get; set; }
    }
}
