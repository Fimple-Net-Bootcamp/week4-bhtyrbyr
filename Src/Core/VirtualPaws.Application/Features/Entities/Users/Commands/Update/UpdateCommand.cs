using MediatR;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Users.Commands.Update
{
    public class UpdateCommand : IRequest<ServiceResponse>
    {
        public UInt16 Id { get; set; }
        public UserUpdateDTO dtoModel { get; set; }

        public UpdateCommand(UInt16 Id, UserUpdateDTO model)
        {
            this.Id = Id;
            dtoModel = model;
        }
        public class UpdateCommandHandler : IRequestHandler<UpdateCommand, ServiceResponse>
        {
            private readonly IUserEntityRepository _userRepo;
            public UpdateCommandHandler(IUserEntityRepository userRepo)
            {
                _userRepo = userRepo;
            }
            public async Task<ServiceResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                var userEntity = _userRepo.GetById(request.Id);
                if (userEntity is null)
                    throw new NoRecordFoundException("PetRepository");
                userEntity.Name = (request.dtoModel.NewName != "string" && request.dtoModel.NewName != null) ? request.dtoModel.NewName : userEntity.Name;
                userEntity.Surname = (request.dtoModel.NewSurname != "string" && request.dtoModel.NewSurname != null) ? request.dtoModel.NewSurname : userEntity.Surname;
                userEntity.Password = (request.dtoModel.NewPassword != "string" && request.dtoModel.NewPassword != null) ? request.dtoModel.NewPassword : userEntity.Password;
                userEntity.UpdateDate = DateTime.Now;
                _userRepo.Update(userEntity);
                return new ServiceResponse("User Service", $"The record named {userEntity.Name} has been successfully updated.");
            }
        }
    }
}
