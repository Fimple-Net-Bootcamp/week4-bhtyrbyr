using AutoMapper;
using VirtualPaws.Application.DTOs.RecordDTOs;
using VirtualPaws.Domain.RecordEntities;

namespace VirtualPaws.Application.Features.Records
{
    public class RecordMappingProfile : Profile
    {
        public RecordMappingProfile()
        {
            CreateMap<ActivityRecord, ActivityRecordViewDTO>()
                .ForMember(
                    dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name)
                )
                .ForMember(
                    dest => dest.UserName, opt => opt.MapFrom(src => $"{src.Owner.Name} {src.Owner.Surname.Substring(0,2)}***")
                )
                .ForMember(
                    dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.Name)
                )
                .ForMember(
                    dest => dest.Comtroller, opt => opt.MapFrom(src => src.Controller)
                )
                .ForMember(
                    dest => dest.Date, opt => opt.MapFrom(src => src.Date)
                );
            CreateMap<FeedRecord, FeedRecordViewDTO>()
                .ForMember(
                    dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name)
                )
                .ForMember(
                    dest => dest.UserName, opt => opt.MapFrom(src => $"{src.Owner.Name} {src.Owner.Surname.Substring(0, 2)}***")
                )
                .ForMember(
                    dest => dest.FoodName, opt => opt.MapFrom(src => src.Food.Name)
                )
                .ForMember(
                    dest => dest.Comtroller, opt => opt.MapFrom(src => src.Controller)
                )
                .ForMember(
                    dest => dest.Date, opt => opt.MapFrom(src => src.Date)
                );
            CreateMap<OwnershipRecord, OwnershipRecordViewDTO>()
                .ForMember(
                    dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name)
                )
                .ForMember(
                    dest => dest.UserName, opt => opt.MapFrom(src => $"{src.Owner.Name} {src.Owner.Surname.Substring(0, 2)}***")
                )
                .ForMember(
                    dest => dest.Comtroller, opt => opt.MapFrom(src => src.Controller)
                )
                .ForMember(
                    dest => dest.Date, opt => opt.MapFrom(src => src.Date)
                );
            CreateMap<TrainingRecord, TrainingRecordViewDTO>()
                .ForMember(
                    dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name)
                )
                .ForMember(
                    dest => dest.UserName, opt => opt.MapFrom(src => $"{src.Owner.Name} {src.Owner.Surname.Substring(0, 2)}***")
                )
                .ForMember(
                    dest => dest.TrainingName, opt => opt.MapFrom(src => src.Training.Name)
                )
                .ForMember(
                    dest => dest.Comtroller, opt => opt.MapFrom(src => src.Controller)
                )
                .ForMember(
                    dest => dest.Date, opt => opt.MapFrom(src => src.Date)
                );
        }
    }
}
