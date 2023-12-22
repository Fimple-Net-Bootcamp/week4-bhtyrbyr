using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPaws.Application.DTOs.OperationDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.Entities;
using VirtualPaws.Domain.RecordEntities;

namespace VirtualPaws.Application.Features.Operations
{
    public class TrainingCommand : IRequest<ServiceResponse>
    {
        public TrainingDTO dtoModel { get; set; }
        public TrainingCommand(TrainingDTO model)
        {
            dtoModel = model;
        }
        public class TrainingCommandHandler : IRequestHandler<TrainingCommand, ServiceResponse>
        {
            private readonly IPetEntityRepository _petRepo;
            private readonly ITrainingEntityRepository _trainingRepo;
            private readonly ITrainingRecordRepository _trainingRecordRepo;

            public TrainingCommandHandler(IPetEntityRepository petRepo, ITrainingEntityRepository trainingRepo, ITrainingRecordRepository trainingRecordRepo)
            {
                _petRepo = petRepo;
                _trainingRepo = trainingRepo;
                _trainingRecordRepo = trainingRecordRepo;
            }

            public async Task<ServiceResponse> Handle(TrainingCommand request, CancellationToken cancellationToken)
            {
                var petEntity = _petRepo.GetById(request.dtoModel.PetId);
                if (petEntity is null) throw new NoRecordFoundException("PetRepository");
                var trainingEntity = _trainingRepo.GetById(request.dtoModel.TrainigId);
                if (trainingEntity is null) throw new NoRecordFoundException("TrainingRepository");
                petEntity.XP += trainingEntity.XP;
                if(petEntity.XP >= 100)
                {
                    petEntity.XP -= 100;
                    petEntity.Level++;
                }
                _petRepo.Update(petEntity);
                _trainingRecordRepo.Create(new TrainingRecord
                {
                    Controller = "Training controller",
                    Date = DateTime.Now,
                    OwnerId = request.dtoModel.UserId,
                    PetId = request.dtoModel.PetId,
                    TrainingId = request.dtoModel.TrainigId
                });
                return new ServiceResponse("Training Service", $"Pet {petEntity.Name} has a new level {petEntity.Level}, xp {petEntity.XP}!");
            }
        }
    }
}
