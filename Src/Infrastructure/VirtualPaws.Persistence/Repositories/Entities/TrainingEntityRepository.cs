using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Domain.Entities;
using VirtualPaws.Persistence.Context;

namespace VirtualPaws.Persistence.Repositories.Entities
{
    public class TrainingEntityRepository : GenericEntityRepository<Training>, ITrainingEntityRepository
    {
        public TrainingEntityRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
