using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.PetFoodDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.PetFoods.Queries
{
    public class GetAllListQuery : IRequest<QueryResponse<List<PetFoodViewDTO>>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllListQuery, QueryResponse<List<PetFoodViewDTO>>>
        {
            private readonly IPetFoodEntityRepository _petFoodRepo;
            private readonly IMapper _mapper;

            public GetAllQueryHandler(IPetFoodEntityRepository petFoodRepo, IMapper mapper)
            {
                _petFoodRepo = petFoodRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<PetFoodViewDTO>>> Handle(GetAllListQuery request, CancellationToken cancellationToken)
            {
                var entities = _petFoodRepo.GetAll().OrderBy(entity => entity.Id).ToList();
                if (!entities.Any())
                    throw new NoRecordFoundException("PetFoodRepository");
                var results = _mapper.Map<List<PetFoodViewDTO>>(entities);
                return new QueryResponse<List<PetFoodViewDTO>>("PetFood Service", $"{results.Count} records were successfully received from database.", results);
            }
        }
    }
}
