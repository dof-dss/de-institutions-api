using AutoMapper;
using de_institutions_api_core.DTOs;

namespace de_institutions_infrastructure.Features.Address.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressDto, de_institutions_api_core.Entities.Address>()
                .ForMember(a => a.Address1, b => b.MapFrom(c => c.Address1.ToUpper()))
                .ForMember(a => a.Address2, b => b.MapFrom(c => c.Address2.ToUpper()))
                .ForMember(a => a.Address3, b => b.MapFrom(c => c.Address3.ToUpper()))
                .ForMember(a => a.TownCity, b => b.MapFrom(c => c.TownCity.ToUpper()))
                .ForMember(a => a.County, b => b.MapFrom(c => c.County.ToUpper()))
                .ForMember(a => a.PostCode, b => b.MapFrom(c => c.PostCode.ToUpper()));

            CreateMap<de_institutions_api_core.Entities.Address, AddressDto>()
                .ForMember(a => a.Address1, b => b.MapFrom(c => c.Address1.ToUpper()))
                .ForMember(a => a.Address2, b => b.MapFrom(c => c.Address2.ToUpper()))
                .ForMember(a => a.Address3, b => b.MapFrom(c => c.Address3.ToUpper()))
                .ForMember(a => a.TownCity, b => b.MapFrom(c => c.TownCity.ToUpper()))
                .ForMember(a => a.County, b => b.MapFrom(c => c.County.ToUpper()))
                .ForMember(a => a.PostCode, b => b.MapFrom(c => c.PostCode.ToUpper()));
        }
    }
}
