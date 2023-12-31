﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VirtualPaws.Persistence.Context;
using VirtualPaws.Persistence.Repositories.Entities;
using VirtualPaws.Application.Interfaces.Repository.Entities;
using VirtualPaws.Application.Interfaces.Repository.Records;
using VirtualPaws.Persistence.Repositories.Records;

namespace VirtualPaws.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionStringinAppSettings)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(
                    connectionString: connectionStringinAppSettings
                    );
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddScoped<IActivityEntityRepository, ActivityEntityRepository>();
            services.AddScoped<IPetEntityRepository, PetEntityRepository>();
            services.AddScoped<IPetFoodEntityRepository, PetFoodEntityRepository>();
            services.AddScoped<IPetHealtStatusEntityRepository, PetHealtStatusEntityRepository>();
            services.AddScoped<IUserEntityRepository, UserEntityRepository>();
            services.AddScoped<ITrainingEntityRepository, TrainingEntityRepository>();
            services.AddScoped<IActivityPetEntityRepository, ActivityPetEntityRepository>();

            services.AddScoped<IActivityRecordRepository, ActivityRecordRepository>();
            services.AddScoped<IFeedRecordRepository, FeedRecordRepository>();
            services.AddScoped<IOwnershipRecordRepository, OwnershipRecordRepository>();
            services.AddScoped<ITrainingRecordRepository, TrainingRecordRepository>();
            return services;
        }
    }
}
