using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.ActivityDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Activities.Queries
{
    public class GetAllListQuery : IRequest<QueryResponse<List<ActivityViewDTO>>>
    {
        public class GetAllListQueryHandler : IRequestHandler<GetAllListQuery, QueryResponse<List<ActivityViewDTO>>>
        {
            private readonly IActivityEntityRepository _petRepo;
            private readonly IUserEntityRepository _userRepo;
            private readonly IMapper _mapper;

            public GetAllListQueryHandler(IActivityEntityRepository petRepo, IUserEntityRepository userRepo, IMapper mapper)
            {
                _petRepo = petRepo;
                _userRepo = userRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<ActivityViewDTO>>> Handle(GetAllListQuery request, CancellationToken cancellationToken)
            {
                var entities = _petRepo.GetAll();
                if (!entities.Any())
                    throw new NoRecordFoundException("ActivityRepository");
                var result = _mapper.Map<List<ActivityViewDTO>>(entities);
                return new QueryResponse<List<ActivityViewDTO>>("Activity Service", $"{result.Count} records were successfully received from database.", result);
            }
        }
    }
}
