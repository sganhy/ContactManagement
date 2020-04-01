namespace ContactManagement.ApplicationCore.Entities
{
    public class ContactRole : EntityBase
    {
        public Contact Contact { get; set; }
        public Company Organization { get; set; }
    }
}
