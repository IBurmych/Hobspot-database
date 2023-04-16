using AutoMapper;
using Hubspot_Dynamics.Entities;
using Hubspot_Dynamics.Models;

namespace Hubspot_Dynamics
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactModel, ContactEntity>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.value));
            CreateMap<ContactModel, ContactEntity>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.value));
        }
    }
}
