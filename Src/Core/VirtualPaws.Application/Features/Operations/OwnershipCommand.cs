using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.DTOs.OperationDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.RecordEntities;

namespace VirtualPaws.Application.Features.Operations
{
    public class OwnershipCommand : IRequest<ServiceResponse>
    {
        public OwnershipDTO dtoModel { get; set; }
        public OwnershipCommand(OwnershipDTO model)
        {
            dtoModel = model;
        }
        public class OwnerchipCommandHandler : IRequestHandler<OwnershipCommand, ServiceResponse>
        {
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IOwnershipRecordRepository _ownershipRepo;

            public OwnerchipCommandHandler(IUserEntityRepository userRepo, IPetEntityRepository petRepo, IOwnershipRecordRepository ownershipRepo)
            {
                _userRepo = userRepo;
                _petRepo = petRepo;
                _ownershipRepo = ownershipRepo;
            }

            public async Task<ServiceResponse> Handle(OwnershipCommand request, CancellationToken cancellationToken)
            {
                var _userEntity = _userRepo.GetById(request.dtoModel.UserId);
                var _petEntity  = _petRepo.GetById(request.dtoModel.PetId);
                if(_userEntity is null) throw new NoRecordFoundException("UserRepository");
                if(_petEntity is null)  throw new NoRecordFoundException("PetRepository");
                if (_petEntity.OwnerId is not null) throw new AlreadyOwnedException();
                _petEntity.OwnerId = _userEntity.Id;
                _petEntity.Owner = _userEntity;
                _petRepo.Update(_petEntity);
                _ownershipRepo.Create(new OwnershipRecord()
                    {
                        OwnerId = _userEntity.Id,
                        Owner = _userEntity,
                        PetId = _petEntity.Id,
                        Pet = _petEntity,
                        Controller = "Ownership controller",
                        Date = DateTime.Now
                    }
                );
                return new ServiceResponse("Ownership Service", $"Pet {_petEntity.Name} was adopted by user {_userEntity.Name}.");
            }
        }
    }
}
