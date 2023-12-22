using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.TrainingDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Trainings.Queries
{
    public class GetAllListQuery : IRequest<QueryResponse<List<TrainingViewDTO>>>
    {
        public class GetAllListQueryHandler : IRequestHandler<GetAllListQuery, QueryResponse<List<TrainingViewDTO>>>
        {
            private readonly ITrainingEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public GetAllListQueryHandler(ITrainingEntityRepository petRepo, IMapper mapper)
            {
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<TrainingViewDTO>>> Handle(GetAllListQuery request, CancellationToken cancellationToken)
            {
                var entities = _petRepo.GetAll().OrderBy(entity => entity.Id).ToList();
                if (!entities.Any())
                    throw new NoRecordFoundException("TrainingRepository");
                var results = _mapper.Map<List<TrainingViewDTO>>(entities);
                return new QueryResponse<List<TrainingViewDTO>>("Training Service", $"{results.Count} records were successfully received from database.", results);
            }
        }
    }
}
