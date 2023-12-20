using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var newEntity = _mapper.Map<PetFood>(request.dtoModel);
                if (_petFoodRepo.GetAll().Any(petFood => petFood.Name == newEntity.Name))
                    throw new AlreadyExistException();
                _petFoodRepo.Create(newEntity);
                request.newId = newEntity.Id;
                return new ServiceResponse("PetFood Service", $"The {newEntity.Name} was successfully registered.");
            }
        }
    }
}
