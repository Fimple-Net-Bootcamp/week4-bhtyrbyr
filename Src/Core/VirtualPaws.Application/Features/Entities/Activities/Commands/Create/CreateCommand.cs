using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.ActivityDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Activities.Commands.Create
{
    public class CreateCommand : IRequest<ServiceResponse>
    {
        public UInt16 newId { get; set; }
        public ActivityCreateDTO dtoModel { get; set; }

        public CreateCommand(ActivityCreateDTO model)
        {
            dtoModel = model;
        }
        public class CreateCommandHandler : IRequestHandler<CreateCommand, ServiceResponse>
        {
            private readonly IActivityEntityRepository _acivityRepo;
            private readonly IMapper _mapper;

            public CreateCommandHandler(IActivityEntityRepository acivityRepo, IMapper mapper)
            {
                _acivityRepo = acivityRepo;
                _mapper = mapper;
            }

            public async Task<ServiceResponse> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                if (_acivityRepo.GetAll().Any(petFood => petFood.Name == request.dtoModel.Name))
                    throw new AlreadyExistException();
                var newEntity = _mapper.Map<Activity>(request.dtoModel);
                _acivityRepo.Create(newEntity);
                request.newId = newEntity.Id;
                return new ServiceResponse("Activity Service", $"The {newEntity.Name} was successfully registered.");
            }
        }
    }
}
