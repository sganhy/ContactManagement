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

            CreateMap<AddressRole, AddressViewModel>()
            .ForMember(w => w.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(w => w.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
            .ForMember(w => w.Id, opt => opt.MapFrom(src => src.Address.Id)
            );

        }
    }
}
