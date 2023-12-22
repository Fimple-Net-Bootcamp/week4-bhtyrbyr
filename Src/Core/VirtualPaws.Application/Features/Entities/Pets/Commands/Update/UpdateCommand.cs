using FluentValidation;
using MediatR;
using VirtualPaws.Application.DTOs.PetDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Features.Entities.Pets.Commands.Create;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Pets.Commands.Update
{
    public class UpdateCommand : IRequest<ServiceResponse>
    {
        public UInt16 Id { get; set; }
        public PetUpdateDTO dtoModel { get; set; }

        public UpdateCommand(UInt16 Id, PetUpdateDTO model)
        {
            this.Id = Id;
            var validator = new PetsUpdateDTOValidator();
            validator.ValidateAndThrow(model);
            dtoModel = model;
        }
        public class UpdatePutCommandHandler : IRequestHandler<UpdateCommand, ServiceResponse>
        {
            private readonly IPetEntityRepository _petRepo;

            public UpdatePutCommandHandler(IPetEntityRepository petRepo)
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
