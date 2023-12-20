using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.DTOs.PetDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Pets.Commands.Update
{
    public class UpdateCommand : IRequest<ServiceResponse>
    {
        public PetUpdateDTO dtoModel { get; set; }
        public UInt16 Id { get; set; }

        public UpdateCommand(UInt16 Id, PetUpdateDTO dtoModel)
        {
            this.Id = Id;
            this.dtoModel = dtoModel;
        }
        public class UpdatePutCommandHandler : IRequestHandler<UpdateCommand, ServiceResponse>
        {
            private readonly IPetEntityRepository _petRepo;

            public UpdatePutCommandHandler(IPetEntityRepository petRepo, IUserEntityRepository userRepo, IMapper mapper)
            {
                _petRepo = petRepo;
            }


            public async Task<ServiceResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                var entity = _petRepo.GetById(request.Id);
                if (entity is null)
                    throw new NoRecordFoundException("PetRepository");
                entity.Name = (request.dtoModel.NewName != "string" && request.dtoModel.NewName != null) ? request.dtoModel.NewName : entity.Name;
                entity.Type = (request.dtoModel.NewType != "string" && request.dtoModel.NewType != null) ? request.dtoModel.NewType : entity.Type;
                entity.Level = request.dtoModel.NewLevel != default ? request.dtoModel.NewLevel : entity.Level;
                entity.XP = request.dtoModel.NewXP != default ? request.dtoModel.NewXP : entity.XP;
                entity.HungerScore = request.dtoModel.NewHungerScore != default ? request.dtoModel.NewHungerScore : entity.HungerScore;
                entity.UpdateDate = DateTime.Now;
                _petRepo.Update(entity);
                return new ServiceResponse("Pet Service", $"The record named {entity.Name} has been successfully updated.");
            }
        }
    }
}
