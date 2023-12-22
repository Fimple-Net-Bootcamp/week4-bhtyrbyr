using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.RecordDTOs;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Records
{
    public class OwnershipRecordCommand : IRequest<QueryResponse<List<OwnershipRecordViewDTO>>>
    {
        public class OwnershipRecordCommandHandler : IRequestHandler<OwnershipRecordCommand, QueryResponse<List<OwnershipRecordViewDTO>>>
        {
            private readonly IOwnershipRecordRepository _recordRepo;
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public OwnershipRecordCommandHandler(IOwnershipRecordRepository recordRepo, IUserEntityRepository userRepo, IPetEntityRepository petRepo, IMapper mapper)
            {
                _recordRepo = recordRepo;
                _userRepo = userRepo;
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<OwnershipRecordViewDTO>>> Handle(OwnershipRecordCommand request, CancellationToken cancellationToken)
            {
                var entities = _recordRepo.GetAll();
                entities.ForEach(record =>
                {
                    record.Pet = _petRepo.GetById(record.PetId);
                    record.Owner = _userRepo.GetById(record.OwnerId);
                });
                var viewEntities = _mapper.Map<List<OwnershipRecordViewDTO>>(entities);
                return new QueryResponse<List<OwnershipRecordViewDTO>>("OwnershipRecord Service", $"{entities.Count} records were successfully received from database.", viewEntities);
            }
        }
    }
}
