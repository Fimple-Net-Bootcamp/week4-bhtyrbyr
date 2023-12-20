using AutoMapper;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserSimplifiedViewDTO>()
                .ForMember(
                    dest => dest.PetCount, opt => opt.MapFrom(src => src.Pets.Count)
                );
            CreateMap<User, UserDetailedViewDTO>()
                .ForMember(
                    dest => dest.PetsName, opt => 
                    opt.MapFrom(src => 
                    !src.Pets.Any() ? null : src.Pets.Select(pet => pet.Name).ToList())
                );
            CreateMap<UserCreateDTO, User>()
                .ForMember(
                    dest => dest.Pets, opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.IsActive, opt => opt.MapFrom(src => true)
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