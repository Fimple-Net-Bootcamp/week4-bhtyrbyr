using AutoMapper;
using VirtualPaws.Application.DTOs.PetDTOs;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Pets
{
    internal class PetMappingProfile : Profile
    {
        public PetMappingProfile()
        {
            CreateMap<Pet, PetSimplifiedViewDTO>()
                .ForMember(
                    dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner == null ? "Sahipsiz" : $"{src.Owner.Name} {src.Owner.Surname.Substring(0,2)}***")
                );
            CreateMap<Pet, PetDetailedViewDTO>()
                .ForMember(
                    dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner == null ? "Sahipsiz" : $"{src.Owner.Name} {src.Owner.Surname.Substring(0, 2)}***")
                )
                .ForMember(
                    dest => dest.Activities, opt => opt.MapFrom(src => src.ActivityPets.Select(activityName => activityName.Activity.Name).ToList())
                );
            CreateMap<PetCreateDTO, Pet>()
                .ForMember(
                    dest => dest.Level, opt => opt.MapFrom(src => 1)
                )
                .ForMember(
                    dest => dest.XP, opt => opt.MapFrom(src => 1)
                )
                .ForMember(
                    dest => dest.HungerScore, opt => opt.MapFrom(src => 100)
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
