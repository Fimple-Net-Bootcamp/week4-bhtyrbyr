using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.DTOs.OperationDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Operations
{
    public class LoginCommand : IRequest<ServiceResponse>
    {
        public LoginDTO dtoModel { get; set; }
        public LoginCommand(LoginDTO model)
        {
            dtoModel = model;
        }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResponse>
        {
            private readonly IUserEntityRepository _userRepo;

            public LoginCommandHandler(IUserEntityRepository userRepo)
            {
                _userRepo = userRepo;
            }

            public async Task<ServiceResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = _userRepo.GetAll().Where(user => user.Username == request.dtoModel.Username).First();
                if (user is null)
                    throw new NoRecordFoundException("UserRepository");
                if (!(user.Password == request.dtoModel.Password))
                    throw new Exception("Kullanıcı adı veya şifresi hatalı!");
                return new ServiceResponse("Login Service", "Successful entry.");
            }
        }
    }
}
