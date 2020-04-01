using System.Diagnostics;

namespace ContactManagement.ApplicationCore.Entities
{
    [DebuggerDisplay("Id = {Id} - City = {City} - ZipdCode = {ZipdCode}")]
    public sealed class Address : EntityBase
    {
        public string City { get; set; }
        public string ZipdCode { get; set; }
        public string Description { get; set; }
    }
}
