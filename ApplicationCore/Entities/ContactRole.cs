namespace ContactManagement.ApplicationCore.Entities
{
    public class ContactRole : EntityBase
    {
        public long ContactId { get; set; }
        public Contact Contact { get; set; }
        public Company Organization { get; set; }
        public long OrganizationId { get; set; }
    }
}
