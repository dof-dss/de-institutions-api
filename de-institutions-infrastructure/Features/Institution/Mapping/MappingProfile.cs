using AutoMapper;
using de_institutions_api_core.DTOs;

namespace de_institutions_infrastructure.Features.Institution.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InstitutionDto, de_institutions_api_core.Entities.Institution>()
             .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<de_institutions_api_core.Entities.Institution, InstitutionDto>()
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}