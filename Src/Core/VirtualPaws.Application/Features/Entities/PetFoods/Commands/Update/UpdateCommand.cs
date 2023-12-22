using FluentValidation;
using MediatR;
using VirtualPaws.Application.DTOs.PetFoodDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.PetFoods.Commands.Update
{
    public class UpdateCommand : IRequest<ServiceResponse>
    {
        public PetFoodUpdateDTO dtoModel { get; set; }
        public UInt16 Id { get; set; }

        public UpdateCommand(UInt16 Id, PetFoodUpdateDTO model)
        {
            this.Id = Id;
            var validator = new PetFoodsUpdateDTOValidator();
            validator.ValidateAndThrow(model);
            dtoModel = model;
        }
        public class UpdateCommandHandler : IRequestHandler<UpdateCommand, ServiceResponse>
        {
            private readonly IPetFoodEntityRepository _petFoodRepo;

            public UpdateCommandHandler(IPetFoodEntityRepository petFoodRepo)
            {
                _petFoodRepo = petFoodRepo;
            }

            public async Task<ServiceResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                var entity = _petFoodRepo.GetById(request.Id);
                if (entity is null)
                    throw new NoRecordFoundException("PetFoodRepository");
                entity.Name = (request.dtoModel.NewName != "string" && request.dtoModel.NewName != null) ? request.dtoModel.NewName : entity.Name;
                entity.NutritionalValue = request.dtoModel.NewNutritionalValue != default ? request.dtoModel.NewNutritionalValue : entity.NutritionalValue;
                entity.UpdateDate = DateTime.Now;
                _petFoodRepo.Update(entity);
                return new ServiceResponse("Pet Service", $"The record named {entity.Name} has been successfully updated.");
            }
        }
    }
}
