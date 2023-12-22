using AutoMapper;
using FluentValidation;
using MediatR;
using VirtualPaws.Application.DTOs.PetFoodDTOs;
using VirtualPaws.Application.DTOs.TrainingDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Features.Entities.Trainings.Commands.Create;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Trainings.Commands.Update
{
    public class UpdateCommand : IRequest<ServiceResponse>
    {
        public UInt16 Id { get; set; }
        public TrainingUpdateDTO dtoModel { get; set; }

        public UpdateCommand(UInt16 Id, TrainingUpdateDTO model)
        {
            this.Id = Id;
            var validator = new TrainingsUpdateDTOValidator();
            validator.ValidateAndThrow(model);
            dtoModel = model;
        }
        public class UpdatePutCommandHandler : IRequestHandler<UpdateCommand, ServiceResponse>
        {
            private readonly ITrainingEntityRepository _petRepo;

            public UpdatePutCommandHandler(ITrainingEntityRepository petRepo)
            {
                _petRepo = petRepo;
            }


            public async Task<ServiceResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                var entity = _petRepo.GetById(request.Id);
                if (entity is null)
                    throw new NoRecordFoundException("TrainingRepository");
                entity.Name = (request.dtoModel.NewName != "string" && request.dtoModel.NewName != null) ? request.dtoModel.NewName : entity.Name;
                entity.XP = request.dtoModel.NewXP != default ? request.dtoModel.NewXP : entity.XP;
                entity.UpdateDate = DateTime.Now;
                _petRepo.Update(entity);
                return new ServiceResponse("Training Service", $"The record named {entity.Name} has been successfully updated.");
            }
        }
    }
}
