using System.Collections.Generic;
using System.Diagnostics;

namespace ContactManagement.ApplicationCore.Entities
{
    [DebuggerDisplay("Id = {Id} - FirstName = {FirstName} - LastName = {LastName}")]
    public sealed class Contact : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Vat { get; set; }
        public long MainAddressId { get; set; }
        public Address MainAddress { get; set; }
        public IEnumerable<ContactRole> ContactRoles { get; set; }
    }
}
