using MediatR;
using Microsoft.EntityFrameworkCore;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Trainings.Commands.Delete
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
            private readonly ITrainingEntityRepository _trainingRepo;
            public DeleteCommandHandler(ITrainingEntityRepository trainingRepo)
            {
                _trainingRepo = trainingRepo;
            }
            public async Task<ServiceResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var entity = _trainingRepo.GetById(request.Id);
                if (entity is null)
                    throw new NoRecordFoundException("TrainingRepository");
                try
                {
                    _trainingRepo.Delete(entity);
                }
                catch (DbUpdateException ex)
                {
                    string[] exMessageParams = ex.InnerException.ToString().Split("\"");
                    string[] ForeignKeyText = exMessageParams[3].Split('_');
                    throw new ViolatesForeignKeyException(exMessageParams[1], exMessageParams[5], ForeignKeyText[ForeignKeyText.Count() - 1]);
                }
                return new ServiceResponse("Training Service", $"{entity.Name} registration successfully deleted.");
            }
        }
    }
}
