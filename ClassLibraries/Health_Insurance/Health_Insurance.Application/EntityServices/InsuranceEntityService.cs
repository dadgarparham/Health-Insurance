using AutoMapper;
using Health_Insurance.Data;
using Health_Insurance.Data.EntityFramework.Contexts;
using Health_Insurance.Domain.Entities;
using Health_Insurance.Domain.Entities.File;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance.Application.EntityServices;

public class InsuranceEntityService : BaseEntityService<InsuranceRequest>, IInsuranceRequestEntityService
{
    private readonly IMapper _mapper;
    private DbSet<Coverage> _coverageEntityService;
    private readonly IPremiumCalculateService _premiumCalculateService;
    public InsuranceEntityService(
        HealthInsuranceDbContext context,
        DbSet<Coverage> coverageEntityService,
        IPremiumCalculateService premiumCalculateService,
        IMapper mapper) : base(context)
    {
        _mapper = mapper;
        _coverageEntityService = coverageEntityService;
        _premiumCalculateService = premiumCalculateService;
    }

    public async Task<ReturnResult<bool>> AddInsuranceRequestAsync(InsuranceRequestDto insuranceRequest, CancellationToken cancellation = default)
    {
        var result = new ReturnResult<bool>();
        var coverages = await _coverageEntityService
            .AsNoTracking()
            .Where(x => insuranceRequest.CoverageIdlist.Contains(x.Id))
            .ToListAsync(cancellation);
        if (coverages is null || !coverages.Any())
        {
            throw new Exception("");
        }
        var created = await CreateAsync(new InsuranceRequest()
        {
            Amount = insuranceRequest.Amount,
            Title = insuranceRequest.Title,
            Coverages = coverages,
            TotalPremium = 100 // ToDo -- get from _premiumCalculateService
        });
        return created ? result.SuccessResult(created) : result.UnSuccessResult("error in created");
    }

    public async Task<ReturnResult<bool>> GetInsuranceRequestAsync(long id, CancellationToken cancellation = default)
    {
        var result = new ReturnResult<bool>();
        var data = await AllAsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync(cancellation);
        return result;
    }
}