namespace ContactManagement.ApplicationCore.Entities
{
    public class AddressRole : EntityBase
    {
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
