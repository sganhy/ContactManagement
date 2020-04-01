using System.Collections.Generic;
using System.Diagnostics;

namespace ContactManagement.ApplicationCore.Entities
{
    [DebuggerDisplay("Id = {Id} - Name = {Name} - Vat = {Vat}")]
    public sealed class Company : EntityBase
    {
        public string Name { get; set; }
        public string Vat { get; set; }
        public long MainAddressId { get; set; }
        public Address MainAddress { get; set; }
        public IEnumerable<AddressRole> AddressRoles { get; set; }
    }
}
