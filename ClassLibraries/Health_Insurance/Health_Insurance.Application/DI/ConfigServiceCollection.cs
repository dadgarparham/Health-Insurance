using AutoMapper;
using Health_Insurance.Application.EntityServices;
using Health_Insurance.Application.Mapper;
using Health_Insurance.Data.EntityFramework.Contexts;
using Health_Insurance.Domain.Entities;
using Health_Insurance.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Health_Insurance.Application.DI;

public static class ConfigServiceCollection
{
    public static void AddContextServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<HealthInsuranceDbContext>((optionsBuilder) =>
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HealthInsuranceCnn") ,
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(1),
                        errorNumbersToAdd: null);
                });
        });
    }

    public static void AddEntityServiceServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IInsuranceRequestEntityService, InsuranceRequestEntityService>();
        services.AddScoped<IPremiumCalculateService, PremiumCalculateService>();
        services.AddSingleton<IMapper>(ApplicationMapper.Mapper);
        services.AddTransient(typeof(Lazy<>), typeof(Lazy<>));
    }


}