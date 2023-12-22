using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.PetFoodDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.PetFoods.Queries
{
    public class GetByIdQuery : IRequest<QueryResponse<PetFoodViewDTO>>
    {
        public UInt16 Id { get; set; }

        public GetByIdQuery(UInt16 Id)
        {
            this.Id = Id;
        }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, QueryResponse<PetFoodViewDTO>>
        {
            private readonly IPetFoodEntityRepository _petFoodRepo;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IPetFoodEntityRepository petFoodRepo, IMapper mapper)
            {
                _petFoodRepo = petFoodRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<PetFoodViewDTO>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = _petFoodRepo.GetById(request.Id);
                if (entity is not null)
                {
                    var result = _mapper.Map<PetFoodViewDTO>(entity);
                    return new QueryResponse<PetFoodViewDTO>("PetFood Service", "The records were successfully retrieved from the database.", result);
                }
                throw new NoRecordFoundException("PetFoodRepository");
            }
        }
    }
}
