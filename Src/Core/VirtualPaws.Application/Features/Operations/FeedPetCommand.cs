using MediatR;
using VirtualPaws.Application.DTOs.OperationDTOs;
using VirtualPaws.Application.Exceptions;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Application.Wrappers;
using VirtualPaws.Domain.RecordEntities;

namespace VirtualPaws.Application.Features.Operations
{
    public class FeedPetCommand : IRequest<ServiceResponse>
    {
        public FeedPetDTO dtoModel { get; set; }
        public FeedPetCommand(FeedPetDTO model)
        {
            dtoModel = model;
        }
        public class FeedPetCommandHandler : IRequestHandler<FeedPetCommand, ServiceResponse>
        {
            private readonly IPetEntityRepository _petRepo;
            private readonly IPetFoodEntityRepository _foodRepo;
            private readonly IFeedRecordRepository _feedRecordRepo;

            public FeedPetCommandHandler(IPetEntityRepository petRepo, IPetFoodEntityRepository foodRepo, IFeedRecordRepository feedRecordRepo)
            {
                _petRepo = petRepo;
                _foodRepo = foodRepo;
                _feedRecordRepo = feedRecordRepo;
            }

            public async Task<ServiceResponse> Handle(FeedPetCommand request, CancellationToken cancellationToken)
            {
                var petEntity = _petRepo.GetById(request.dtoModel.PetId);
                if (petEntity is null) throw new NoRecordFoundException("PetRepository");
                var foodEntity = _foodRepo.GetById(request.dtoModel.FoodId);
                if (foodEntity is null) throw new NoRecordFoundException("PetFoodRepository");
                petEntity.HungerScore += foodEntity.NutritionalValue;
                if (petEntity.HungerScore >= 100) petEntity.HungerScore = 100;
                _petRepo.Update(petEntity);
                _feedRecordRepo.Create(new FeedRecord()
                {
                    OwnerId = request.dtoModel.UserId,
                    FoodId = request.dtoModel.FoodId,
                    PetId = request.dtoModel.PetId,
                    Date = DateTime.Now,
                    Controller = "Feed controller"
                });
                return new ServiceResponse("Feed Service", $"Pet {petEntity.Name} was fed with food {foodEntity.Name}.");
            }
        }
    }
}
