using System.Runtime.Serialization;

namespace Hubspot_Dynamics.Enums
{
    public enum EventType
    {
        [EnumMember(Value = "contact.creation")]
        Created = 1,

        [EnumMember(Value = "contact.deletion")]
        Deleted = 2,

        [EnumMember(Value = "contact.merge")]
        Merged = 3,

        [EnumMember(Value = "contact.associationChange")]
        AssociationChanged = 4,

        [EnumMember(Value = "contact.restore")]
        Restored = 5,

        [EnumMember(Value = "contact.privacyDeletion")]
        PrivacyDeleted = 6,

        [EnumMember(Value = "contact.propertyChange")]
        PropertyChanged = 8
        // todo: add another events
    }
}
