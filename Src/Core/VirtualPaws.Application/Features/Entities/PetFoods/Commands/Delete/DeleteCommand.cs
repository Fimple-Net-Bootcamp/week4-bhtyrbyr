using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Wrappers;

namespace VirtualPaws.Application.Features.Entities.PetFoods.Commands.Delete
{
    public class DeleteCommand : IRequest<ServiceResponse>
    {
        public UInt16 id { get; set; }

        public DeleteCommand(ushort id)
        {
            this.id = id;
        }
        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ServiceResponse>
        {
            private readonly IPetFoodEntityRepository _petFoodRepo;

            public DeleteCommandHandler(IPetFoodEntityRepository petFoodRepo)
            {
                _petFoodRepo = petFoodRepo;
            }

            public async Task<ServiceResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var entity = _petFoodRepo.GetById(request.id);
                if (entity is null)
                    throw new NoRecordFoundException("PetFoodRepository");
                try
                {
                    _petFoodRepo.Delete(entity);
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
