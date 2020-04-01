namespace ContactManagement.ApplicationCore.Entities
{
    public class AddressRole : EntityBase
    {
        public Address Address { get; set; }
        public Company Company { get; set; }
    }
}
