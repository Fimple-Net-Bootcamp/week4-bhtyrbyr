using AutoMapper;
using FluentValidation;
using MediatR;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Users.Commands.Create
{
    public class CreateCommand : IRequest<ServiceResponse>
    {
        public UInt16 newId { get; set; }
        public UserCreateDTO dtoModel { get; set; }

        public CreateCommand(UserCreateDTO model)
        {
            var validator = new UsersCreateDTOValidator();
            validator.ValidateAndThrow(model);
            dtoModel = model;
        }
        public class CreateCommandHandler : IRequestHandler<CreateCommand, ServiceResponse>
        {
            private readonly IUserEntityRepository _userRepo;
            private readonly IMapper _mapper;

            public CreateCommandHandler(IUserEntityRepository userRepo, IMapper mapper)
            {
                _userRepo = userRepo;
                _mapper = mapper;
            }

            public async Task<ServiceResponse> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                if (_userRepo.GetAll().Any(user => user.Username == request.dtoModel.Username))
                    throw new AlreadyExistException();
                var newEntity = _mapper.Map<User>(request.dtoModel);
                _userRepo.Create(newEntity);
                request.newId = newEntity.Id;
                return new ServiceResponse("User Service", $"The {newEntity.Username} was successfully registered.");
            }
        }
    }
}
