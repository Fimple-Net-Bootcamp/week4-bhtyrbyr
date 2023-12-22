using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.TrainingDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Trainings.Commands.Create
{
    public class CreateCommand : IRequest<ServiceResponse>
    {
        public UInt16 newId { get; set; }
        public TrainingCreateDTO dtoModel { get; set; }

        public CreateCommand(TrainingCreateDTO model)
        {
            dtoModel = model;
        }
        public class CreateCommandHandler : IRequestHandler<CreateCommand, ServiceResponse>
        {
            private readonly ITrainingEntityRepository _trainingRepo;
            private readonly IMapper _mapper;

            public CreateCommandHandler(ITrainingEntityRepository trainingRepo, IMapper mapper)
            {
                _trainingRepo = trainingRepo;
                _mapper = mapper;
            }

            public async Task<ServiceResponse> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                if (_trainingRepo.GetAll().Any(training => training.Name == request.dtoModel.Name))
                    throw new AlreadyExistException();
                var newEntity = _mapper.Map<Training>(request.dtoModel);
                _trainingRepo.Create(newEntity);
                request.newId = newEntity.Id;
                return new ServiceResponse("Training Service", $"The {newEntity.Name} was successfully registered.");
            }
        }
    }
}
