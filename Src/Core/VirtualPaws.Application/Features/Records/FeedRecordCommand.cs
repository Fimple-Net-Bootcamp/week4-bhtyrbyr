using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.RecordDTOs;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Records
{
    public class FeedRecordCommand : IRequest<QueryResponse<List<FeedRecordViewDTO>>>
    {
        public class FeedRecordCommandHandler : IRequestHandler<FeedRecordCommand, QueryResponse<List<FeedRecordViewDTO>>>
        {
            private readonly IFeedRecordRepository _recordRepo;
            private readonly IPetFoodEntityRepository _foodRepo;
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public FeedRecordCommandHandler(IFeedRecordRepository recordRepo, IPetFoodEntityRepository foodRepo, IUserEntityRepository userRepo, IPetEntityRepository petRepo, IMapper mapper)
            {
                _recordRepo = recordRepo;
                _foodRepo = foodRepo;
                _userRepo = userRepo;
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<FeedRecordViewDTO>>> Handle(FeedRecordCommand request, CancellationToken cancellationToken)
            {
                var entities = _recordRepo.GetAll();
                entities.ForEach(record =>
                {
                    record.Food = _foodRepo.GetById(record.FoodId);
                    record.Pet = _petRepo.GetById(record.PetId);
                    record.Owner = _userRepo.GetById(record.OwnerId);
                });
                var viewEntities = _mapper.Map<List<FeedRecordViewDTO>>(entities);
                return new QueryResponse<List<FeedRecordViewDTO>>("FeedRecord Service", $"{entities.Count} records were successfully received from database.", viewEntities);
            }
        }
    }
}
