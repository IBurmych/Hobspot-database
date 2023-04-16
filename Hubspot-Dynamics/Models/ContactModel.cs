namespace Hubspot_Dynamics.Models
{
    public class ContactModel
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Email Email { get; set; }
        public BirthDate BirthDate { get; set; }
    }

    public class BirthDate
    {
        public DateTime? value { get; set; }
    }
    public class Email
    {
        public string? value { get; set; }
    }
    public class LastName
    {
        public string? value { get; set; }
    }
    public class FirstName
    {
        public string? value { get; set; }
    }
}
