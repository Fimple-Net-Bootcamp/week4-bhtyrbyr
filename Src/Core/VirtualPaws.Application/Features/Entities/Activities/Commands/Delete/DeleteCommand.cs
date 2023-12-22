using MediatR;
using Microsoft.EntityFrameworkCore;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Activities.Commands.Delete
{
    public class DeleteCommand : IRequest<ServiceResponse>
    {
        public UInt16 Id { get; set; }

        public DeleteCommand(UInt16 Id)
        {
            this.Id = Id;
        }
        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ServiceResponse>
        {
            private readonly IActivityEntityRepository _activityRepo;

            public DeleteCommandHandler(IActivityEntityRepository activityRepo)
            {
                _activityRepo = activityRepo;
            }

            public async Task<ServiceResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var entity = _activityRepo.GetById(request.Id);
                if (entity is null)
                    throw new NoRecordFoundException("ActivityRepository");
                try
                {
                    _activityRepo.Delete(entity);
                }
                catch (DbUpdateException ex)
                {
                    string[] exMessageParams = ex.InnerException.ToString().Split("\"");
                    string[] ForeignKeyText = exMessageParams[3].Split('_');
                    throw new ViolatesForeignKeyException(exMessageParams[1], exMessageParams[5], ForeignKeyText[ForeignKeyText.Count() - 1]);
                }
                return new ServiceResponse("Pet Service", $"{entity.Name} registration successfully deleted.");
            }
        }
    }
}
