using AutoMapper;
using ContactManagement.ApplicationCore.Entities;
using ContactManagement.Web.Models;

namespace ContactManagement.Web.Mappings
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressViewModel>()
            .ForMember(w => w.City, opt => opt.MapFrom(src => src.City)
            ).ReverseMap();
        }
    }
}
