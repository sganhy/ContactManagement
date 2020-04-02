using System.Collections.Generic;

namespace ContactManagement.Web.Models
{
    public class CompanyViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Vat { get; set; }
        public AddressViewModel MainAddress { get; set; }
        public IEnumerable<AddressViewModel> Addresses { get; set; }
    }
}
