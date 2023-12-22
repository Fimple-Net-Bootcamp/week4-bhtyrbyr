using AutoMapper;
using MediatR;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Activities.Queries
{
    public class GetAllListQuery : IRequest<QueryResponse<List<Activity>>>
    {
        public class GetAllListQueryHandler : IRequestHandler<GetAllListQuery, QueryResponse<List<Activity>>>
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

            public async Task<QueryResponse<List<Activity>>> Handle(GetAllListQuery request, CancellationToken cancellationToken)
            {
                var entities = _petRepo.GetAll();
                if (!entities.Any())
                    throw new NoRecordFoundException("ActivityRepository");
                /*entities.ForEach(entity =>
                {
                    if (entity.OwnerId is not null)
                        entity.Owner = _userRepo.GetById((UInt16)entity.OwnerId);
                });*/
                var results = /*_mapper.Map<List<Activity>>(entities);*/ entities;
                return new QueryResponse<List<Activity>>("Activity Service", $"{results.Count} records were successfully received from database.", results);
            }
        }
    }
}
