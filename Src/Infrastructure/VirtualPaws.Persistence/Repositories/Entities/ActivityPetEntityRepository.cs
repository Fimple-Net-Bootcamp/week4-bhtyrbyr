using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Domain.Entities;
using VirtualPaws.Persistence.Context;

namespace VirtualPaws.Persistence.Repositories.Entities
{
    public class ActivityPetEntityRepository : GenericEntityRepository<ActivityPet>, IActivityPetEntityRepository
    {
        public ActivityPetEntityRepository(AppDbContext _dbContext) : base(_dbContext)
        { }
    }
}
