using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Users.Commands.Create
{
    public class CreateCommand : IRequest<ServiceResponse>
    {
        public CreateCommand(UserCreateDTO dtoModel)
        {
            this.dtoModel = dtoModel;
        }
        public UInt16 newId { get; set; }
        public UserCreateDTO dtoModel { get; set; }
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
                var newEntity = _mapper.Map<User>(request.dtoModel);
                if (_userRepo.GetAll().Any(user => user.Username == newEntity.Username))
                    throw new AlreadyExistException();
                _userRepo.Create(newEntity);
                request.newId = newEntity.Id;
                return new ServiceResponse("User Service", $"The {newEntity.Username} was successfully registered.");
            }
        }
    }
}
