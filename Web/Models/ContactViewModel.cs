using System.Collections.Generic;

namespace ContactManagement.Web.Models
{
    public class ContactViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressViewModel MainAddress { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}
