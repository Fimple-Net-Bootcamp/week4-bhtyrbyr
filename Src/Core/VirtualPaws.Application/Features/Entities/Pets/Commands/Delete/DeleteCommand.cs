﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;

namespace VirtualPaws.Application.Features.Entities.Pets.Commands.Delete
{
    public class DeleteCommand : IRequest<ServiceResponse>
    {
        public UInt16 id { get; set; }
        public DeleteCommand(UInt16 id)
        {
            this.id = id;
        }
        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ServiceResponse>
        {
            private readonly IPetEntityRepository _petRepo;

            public DeleteCommandHandler(IPetEntityRepository petRepo)
            {
                _petRepo = petRepo;
            }

            public async Task<ServiceResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var entity = _petRepo.GetById(request.id);
                if (entity is null)
                    throw new NoRecordFoundException("PetRepository");
                try
                {
                    _petRepo.Delete(entity);
                }
                catch (DbUpdateException ex)
                {
                    string[] exMessageParams = ex.InnerException.ToString().Split("\"");
                    string[] ForeignKeyText = exMessageParams[3].Split('_');
                    throw new ViolatesForeignKeyException(exMessageParams[1], exMessageParams[5], ForeignKeyText[ForeignKeyText.Count() - 1]);
                }
                return new ServiceResponse("Pet Service", $"{entity.Name} registration successfully deleted.");
            }
        }
    }
}
