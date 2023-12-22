using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.PetDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Pets.Commands.Create
{
    public class CreateCommand : IRequest<ServiceResponse>
    {
        public UInt16 newId { get; set; }
        public PetCreateDTO dtoModel { get; set; }

        public CreateCommand(PetCreateDTO model)
        {
            dtoModel = model;
        }
        public class CreateCommandHandler : IRequestHandler<CreateCommand, ServiceResponse>
        {
            private readonly IPetEntityRepository _petRepo;
            private readonly IActivityEntityRepository _activityRepo;
            private readonly IActivityPetEntityRepository _activityPetRepo;
            private readonly IMapper _mapper;

            public CreateCommandHandler(IPetEntityRepository petRepo, IActivityEntityRepository activityRepo, IActivityPetEntityRepository activityPetRepo, IMapper mapper)
            {
                _petRepo = petRepo;
                _activityRepo = activityRepo;
                _activityPetRepo = activityPetRepo;
                _mapper = mapper;
            }

            public async Task<ServiceResponse> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                if (_petRepo.GetAll().Any(user => user.Name == request.dtoModel.Name))
                    throw new AlreadyExistException();
                var newEntity = _mapper.Map<Pet>(request.dtoModel);
                _petRepo.Create(newEntity);
                request.newId = newEntity.Id;
                return new ServiceResponse("Pet Service", $"The {newEntity.Name} was successfully registered.");
            }
        }
    }
}
