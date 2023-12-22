using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.RecordDTOs;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Records
{
    public class TrainingRecordCommand : IRequest<QueryResponse<List<TrainingRecordViewDTO>>>
    {
        public class TrainingRecordCommandHandler : IRequestHandler<TrainingRecordCommand, QueryResponse<List<TrainingRecordViewDTO>>>
        {
            private readonly ITrainingRecordRepository _recordRepo;
            private readonly ITrainingEntityRepository _activityRepo;
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public TrainingRecordCommandHandler(ITrainingRecordRepository recordRepo, ITrainingEntityRepository activityRepo, IUserEntityRepository userRepo, IPetEntityRepository petRepo, IMapper mapper)
            {
                _recordRepo = recordRepo;
                _activityRepo = activityRepo;
                _userRepo = userRepo;
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<TrainingRecordViewDTO>>> Handle(TrainingRecordCommand request, CancellationToken cancellationToken)
            {
                var entities = _recordRepo.GetAll();
                entities.ForEach(record =>
                {
                    record.Training = _activityRepo.GetById(record.TrainingId);
                    record.Pet = _petRepo.GetById(record.PetId);
                    record.Owner = _userRepo.GetById(record.OwnerId);
                });
                var viewEntities = _mapper.Map<List<TrainingRecordViewDTO>>(entities);
                return new QueryResponse<List<TrainingRecordViewDTO>>("TrainingRecord Service", $"{entities.Count} records were successfully received from database.", viewEntities);
            }
        }
    }
}
