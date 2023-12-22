using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.RecordDTOs;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Records
{
    public class ActivityRecordCommand : IRequest<QueryResponse<List<ActivityRecordViewDTO>>>
    {
        public class ActivityRecordCommandHandler : IRequestHandler<ActivityRecordCommand, QueryResponse<List<ActivityRecordViewDTO>>>
        {
            private readonly IActivityRecordRepository _recordRepo;
            private readonly IActivityEntityRepository _activityRepo;
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public ActivityRecordCommandHandler(IActivityRecordRepository recordRepo, IActivityEntityRepository activityRepo, IUserEntityRepository userRepo, IPetEntityRepository petRepo, IMapper mapper)
            {
                _recordRepo = recordRepo;
                _activityRepo = activityRepo;
                _userRepo = userRepo;
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<ActivityRecordViewDTO>>> Handle(ActivityRecordCommand request, CancellationToken cancellationToken)
            {
                var entities = _recordRepo.GetAll();
                entities.ForEach(record =>
                {
                    record.Activity = _activityRepo.GetById(record.ActivityId);
                    record.Pet = _petRepo.GetById(record.PetId);
                    record.Owner = _userRepo.GetById(record.OwnerId);
                });
                var viewEntities = _mapper.Map<List<ActivityRecordViewDTO>>(entities);
                return new QueryResponse<List<ActivityRecordViewDTO>>("ActivityRecord Service", $"{entities.Count} records were successfully received from database.", viewEntities);
            }
        }
    }
}
