using AutoMapper;
using Health_Insurance.Application.EntityServices;
using Health_Insurance.Application.Mapper;
using Health_Insurance.Data.EntityFramework.Contexts;
using Health_Insurance.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Health_Insurance.Application.DI;

public static class ConfigServiceCollection
{
    public static void AddContextServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<DataContext>((optionsBuilder) =>
        {
            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("FilManagerCnn"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(1),
                        errorNumbersToAdd: null);
                });
        });
    }

    public static void AddEntityServiceServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IInsuranceEntityService, InsuranceEntityService>();

        services.AddSingleton<IMapper>(ApplicationMapper.Mapper);
        services.AddTransient(typeof(Lazy<>), typeof(Lazy<>));
    }


}