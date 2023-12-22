using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.ActivityDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Activities.Queries
{
    public class GetByIdQuery : IRequest<QueryResponse<ActivityViewDTO>>
    {
        public UInt16 Id { get; set; }

        public GetByIdQuery(UInt16 Id)
        {
            this.Id = Id;
        }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, QueryResponse<ActivityViewDTO>>
        {
            private readonly IActivityEntityRepository _petRepo;
            private readonly IUserEntityRepository _userRepo;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IActivityEntityRepository petRepo, IUserEntityRepository userRepo, IMapper mapper)
            {
                _petRepo = petRepo;
                _userRepo = userRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<ActivityViewDTO>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = _petRepo.GetById(request.Id);
                if (entity is not null)
                {
                    var result = _mapper.Map<ActivityViewDTO>(entity);
                    return new QueryResponse<ActivityViewDTO>("Activity Service", "The record was successfully retrieved from the database.", result);
                }
                throw new NoRecordFoundException("ActivityRepository");
            }
        }
    }
}
