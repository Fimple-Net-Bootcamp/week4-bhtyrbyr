using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.TrainingDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Trainings.Queries
{
    public class GetByIdQuery : IRequest<QueryResponse<TrainingViewDTO>>
    {
        public UInt16 Id { get; set; }
        public GetByIdQuery(UInt16 Id)
        {
            this.Id = Id;
        }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, QueryResponse<TrainingViewDTO>>
        {
            private readonly ITrainingEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(ITrainingEntityRepository petRepo, IMapper mapper)
            {
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<TrainingViewDTO>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = _petRepo.GetById(request.Id);
                if (entity is not null)
                {
                    var result = _mapper.Map<TrainingViewDTO>(entity);
                    return new QueryResponse<TrainingViewDTO>("Training Service", "The record was successfully retrieved from the database.", result);
                }
                throw new NoRecordFoundException("TrainingRepository");
            }
        }
    }
}
