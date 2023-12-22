using AutoMapper;
using MediatR;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Users.Queries
{
    public class GetAllListQuery : IRequest<QueryResponse<List<UserSimplifiedViewDTO>>>
    {
        public class GetAllListQueryHandler : IRequestHandler<GetAllListQuery, QueryResponse<List<UserSimplifiedViewDTO>>>
        {
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public GetAllListQueryHandler(IUserEntityRepository userRepo, IPetEntityRepository petRepo, IMapper mapper)
            {
                _userRepo = userRepo;
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<List<UserSimplifiedViewDTO>>> Handle(GetAllListQuery request, CancellationToken cancellationToken)
            {
                var entities = _userRepo.GetAll();
                if (!entities.Any())
                    throw new NoRecordFoundException("UserRepository");
                entities.ForEach(entity =>
                {
                    entity.Pets = _petRepo.GetAll().Where(pet => pet.OwnerId == entity.Id).ToList();
                });
                var results = _mapper.Map<List<UserSimplifiedViewDTO>>(entities);
                return new QueryResponse<List<UserSimplifiedViewDTO>>("User Service", $"{results.Count} records were successfully received from database.", results);
            }
        }
    }
}
