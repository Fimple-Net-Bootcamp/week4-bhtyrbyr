using AutoMapper;
using FluentValidation;
using MediatR;
using VirtualPaws.Application.DTOs.PetFoodDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.PetFoods.Commands.Create
{
    public class CreateCommand : IRequest<ServiceResponse>
    {
        public UInt16 newId { get; set; }
        public PetFoodCreateDTO dtoModel { get; set; }

        public CreateCommand(PetFoodCreateDTO model)
        {
            var validator = new PetFoodsCreateDTOValidator();
            validator.ValidateAndThrow(model);
            dtoModel = model;
        }
        public class CreateCommandHandler : IRequestHandler<CreateCommand, ServiceResponse>
        {
            private readonly IPetFoodEntityRepository _petFoodRepo;
            private readonly IMapper _mapper;

            public CreateCommandHandler(IPetFoodEntityRepository petFoodRepo, IMapper mapper)
            {
                _petFoodRepo = petFoodRepo;
                _mapper = mapper;
            }

            public async Task<ServiceResponse> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                if (_petFoodRepo.GetAll().Any(petFood => petFood.Name == request.dtoModel.Name))
                    throw new AlreadyExistException();
                var newEntity = _mapper.Map<PetFood>(request.dtoModel);
                _petFoodRepo.Create(newEntity);
                request.newId = newEntity.Id;
                return new ServiceResponse("PetFood Service", $"The {newEntity.Name} was successfully registered.");
            }
        }
    }
}
