using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.Users.Queries
{
    public class GetByIdQuery : IRequest<QueryResponse<UserDetailedViewDTO>>
    {
        public UInt16 Id { get; set; }
        public GetByIdQuery(UInt16 Id)
        {
            this.Id = Id;
        }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, QueryResponse<UserDetailedViewDTO>>
        {
            private readonly IUserEntityRepository _userRepo;
            private readonly IPetEntityRepository _petRepo;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IUserEntityRepository userRepo, IPetEntityRepository petRepo, IMapper mapper)
            {
                _userRepo = userRepo;
                _petRepo = petRepo;
                _mapper = mapper;
            }

            public async Task<QueryResponse<UserDetailedViewDTO>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = _userRepo.GetById(request.Id);
                if (entity is not null)
                {
                    entity.Pets = _petRepo.GetAll().Where(pet => pet.OwnerId == entity.Id).ToList();
                    var result = _mapper.Map<UserDetailedViewDTO>(entity);
                    return new QueryResponse<UserDetailedViewDTO>("User Service", "The records were successfully retrieved from the database.", result);

                }
                throw new NoRecordFoundException();
            }
        }
    }
}
