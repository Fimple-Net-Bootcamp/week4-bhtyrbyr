﻿using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Domain.RecordEntities;
using VirtualPaws.Persistence.Context;

namespace VirtualPaws.Persistence.Repositories.Records
{
    public class TrainingRecordRepository : GenericRecordRepository<TrainingRecord>, ITrainingRecordRepository
    {
        public TrainingRecordRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
