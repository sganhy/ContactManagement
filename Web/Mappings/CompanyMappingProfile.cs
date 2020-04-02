using AutoMapper;
using ContactManagement.ApplicationCore.Entities;
using ContactManagement.Web.Models;

namespace ContactManagement.Web.Mappings
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyViewModel>()
                .ForMember(w => w.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(w => w.Addresses, opt => opt.MapFrom(src => src.AddressRoles))
                .ForMember(w => w.MainAddress, opt => opt.MapFrom(src => src.MainAddress))
                .ForMember(w => w.Vat, opt => opt.MapFrom(src => src.Vat));

            CreateMap<CompanyViewModel, Company>()
                .ForMember(w => w.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(w => w.AddressRoles, opt => opt.NullSubstitute(string.Empty))
                .ForMember(w => w.MainAddress, opt => opt.MapFrom(src => src.MainAddress))
                .ForMember(w => w.Vat, opt => opt.MapFrom(src => src.Vat));
        }
    }
}
