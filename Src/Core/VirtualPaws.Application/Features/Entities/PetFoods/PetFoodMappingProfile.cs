using AutoMapper;
using VirtualPaws.Application.DTOs.PetFoodDTOs;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.PetFoods
{
    public class PetFoodMappingProfile : Profile
    {
        public PetFoodMappingProfile()
        {
            CreateMap<PetFood, PetFoodViewDTO>();
            CreateMap<PetFoodCreateDTO, PetFood>()
                .ForMember(
                    dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now)
                )
                .ForMember(
                    dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.Now)
                );
        }
    }
}
