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
                .ForMember(w => w.Vat, opt => opt.MapFrom(src => src.Vat)).ReverseMap();
        }
    }
}
