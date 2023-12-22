using AutoMapper;
using VirtualPaws.Application.DTOs.ActivityDTOs;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Activities
{
    public class ActivityMappingProfile : Profile
    {
        public ActivityMappingProfile()
        {
            CreateMap<Activity, ActivityViewDTO>();
            CreateMap<ActivityCreateDTO, Activity>()
                .ForMember(
                    dest => dest.ActivityPets, opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now)
                )
                .ForMember(
                    dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.Now)
                );
        }
    }
}
