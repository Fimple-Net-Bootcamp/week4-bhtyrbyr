using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.DTOs.TrainingDTOs;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Trainings
{
    public class TrainingMappingProfile : Profile
    {
        public TrainingMappingProfile()
        {
            CreateMap<Training, TrainingViewDTO>();
            CreateMap<TrainingCreateDTO, Training>()
                .ForMember(
                    dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now)
                )
                .ForMember(
                    dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.Now)
                );
        }
    }
}
