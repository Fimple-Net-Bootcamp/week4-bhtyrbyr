using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.PetDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Pets.Queries
{
    public class GetByIdQuery : IRequest<QueryResponse<PetDetailedViewDTO>>
    {
        public UInt16 Id { get; set; }

        public GetByIdQuery(UInt16 Id)
        {
            this.Id = Id;
        }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, QueryResponse<PetDetailedViewDTO>>
        {
            private readonly IPetEntityRepository _petRepo;
            private readonly IUserEntityRepository _userRepo;
            private readonly IActivityEntityRepository _activityRepo;
            private readonly IActivityPetEntityRepository _activityPetRepo;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IPetEntityRepository petRepo, IUserEntityRepository userRepo, IActivityPetEntityRepository activityPetRepo, IMapper mapper, IActivityEntityRepository activityRepo = null)
            {
                _petRepo = petRepo;
                _userRepo = userRepo;
                _activityPetRepo = activityPetRepo;
                _mapper = mapper;
                _activityRepo = activityRepo;
            }

            public async Task<QueryResponse<PetDetailedViewDTO>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = _petRepo.GetById(request.Id);
                if (entity is not null)
                {
                    if (entity.OwnerId is not null)
                    {
                        entity.Owner = _userRepo.GetById((UInt16)entity.OwnerId);
                    }
                    var permisions = _activityPetRepo.GetAll();
                    var activities = _activityRepo.GetAll();
                    entity.ActivityPets = permisions.Where(permision => permision.PetId == request.Id).ToList();
                    entity.ActivityPets.ForEach(activity =>
                    {
                        activity.Activity = activities.First(entity => entity.Id == activity.ActivityId);
                    });
                    var result = _mapper.Map<PetDetailedViewDTO>(entity);
                    return new QueryResponse<PetDetailedViewDTO>("Pet Service", "The record was successfully retrieved from the database.", result);
                }
                throw new NoRecordFoundException("PetRepository");
            }
        }
    }
}
