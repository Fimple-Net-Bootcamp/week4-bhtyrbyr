using MediatR;
using VirtualPaws.Application.DTOs.OperationDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.RecordEntities;

namespace VirtualPaws.Application.Features.Operations
{
    public class DoActivityCommand : IRequest<ServiceResponse>
    {
        public DoActivityDTO dtoModel{ get; set; }
        public DoActivityCommand(DoActivityDTO model)
        {
            dtoModel = model;
        }
        public class DoActivityCommandHandler : IRequestHandler<DoActivityCommand, ServiceResponse>
        {
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IActivityEntityRepository _activityRepo;
            private readonly IActivityPetEntityRepository _activityPetRepo;
            private readonly IActivityRecordRepository _activityRecordRepo;
            private readonly IPetHealtStatusEntityRepository _petHealtStatusRepo;

            public DoActivityCommandHandler(IUserEntityRepository userRepo, IPetEntityRepository petRepo, IActivityEntityRepository activityRepo, IActivityPetEntityRepository activityPetRepo, IActivityRecordRepository activityRecordRepo, IPetHealtStatusEntityRepository petHealtStatusRepo)
            {
                _userRepo = userRepo;
                _petRepo = petRepo;
                _activityRepo = activityRepo;
                _activityPetRepo = activityPetRepo;
                _activityRecordRepo = activityRecordRepo;
                _petHealtStatusRepo = petHealtStatusRepo;
            }

            public async Task<ServiceResponse> Handle(DoActivityCommand request, CancellationToken cancellationToken)
            {
                var _userEntity = _userRepo.GetById(request.dtoModel.OwnerId);
                if (_userEntity is null) throw new NoRecordFoundException("UserRepository");
                var _activityPetEntity = _activityPetRepo.GetAll().Where(pet => pet.PetId == request.dtoModel.PetId).ToList();
                if (_activityPetEntity is null) throw new NoRecordFoundException("ActivityPeyRepository");
                var _activityEntity = _activityRepo.GetById(request.dtoModel.ActivityId);
                if (_activityEntity is null) throw new NoRecordFoundException("ActivityRepository");
                var _petEntity = _petRepo.GetById(request.dtoModel.PetId);
                if (_petEntity is null) throw new NoRecordFoundException("PetRepository");

                if (!_activityPetEntity.Any(entity => entity.PetId == request.dtoModel.PetId))
                    throw new NoCapabilityForActivityException(_petEntity.Name, _activityEntity.Name);
                var _petHealtStatusEntity = _petHealtStatusRepo.GetAll().First(pet => pet.Id == _petEntity.Id);
                if (_petHealtStatusEntity.HealtScore + _activityEntity.NutritionalValue <= 100)
                    _petHealtStatusEntity.HealtScore += _activityEntity.NutritionalValue;
                else
                    _petHealtStatusEntity.HealtScore = 100;
                _petHealtStatusRepo.Update(_petHealtStatusEntity);
                
                _petEntity.HungerScore -= _activityEntity.NutritionalValue;
                _petRepo.Update(_petEntity);

                _activityRecordRepo.Create(new ActivityRecord()
                {
                    PetId = _petEntity.Id,
                    ActivityId = _activityEntity.Id,
                    OwnerId = _userEntity.Id,
                    Date = DateTime.Now,
                    Controller = "DoActivity controller"
                });
                return new ServiceResponse("DoActivity Service", $"User {_userEntity.Name} successfully performed activity {_activityEntity.Name} with pet {_petEntity.Name}.");
                


            }
        }
    }
}
