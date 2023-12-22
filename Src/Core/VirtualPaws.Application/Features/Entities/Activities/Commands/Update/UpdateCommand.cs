using MediatR;
using VirtualPaws.Application.DTOs.ActivityDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Activitys.Commands.Update
{
    public class UpdateCommand : IRequest<ServiceResponse>
    {
        public ActivityUpdateDTO dtoModel { get; set; }
        public UInt16 Id { get; set; }

        public UpdateCommand(UInt16 Id, ActivityUpdateDTO model)
        {
            this.Id = Id;
            dtoModel = model;
        }
        public class UpdateCommandHandler : IRequestHandler<UpdateCommand, ServiceResponse>
        {
            private readonly IActivityEntityRepository _activityRepo;

            public UpdateCommandHandler(IActivityEntityRepository activityRepo)
            {
                _activityRepo = activityRepo;
            }

            public async Task<ServiceResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                var entity = _activityRepo.GetById(request.Id);
                if (entity is null)
                    throw new NoRecordFoundException("ActivityRepository");
                entity.Name = (request.dtoModel.NewName != "string" && request.dtoModel.NewName != null) ? request.dtoModel.NewName : entity.Name;
                entity.NutritionalValue = request.dtoModel.NewNutritionalValue != default ? request.dtoModel.NewNutritionalValue : entity.NutritionalValue;
                entity.UpdateDate = DateTime.Now;
                _activityRepo.Update(entity);
                return new ServiceResponse("Pet Service", $"The record named {entity.Name} has been successfully updated.");
            }
        }
    }
}
