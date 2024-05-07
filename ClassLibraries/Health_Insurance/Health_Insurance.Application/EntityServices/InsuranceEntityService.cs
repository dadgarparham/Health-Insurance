using Health_Insurance.Data;
using Health_Insurance.Data.EntityFramework.Contexts;
using Health_Insurance.Domain.Entities;
using Health_Insurance.Domain.Entities.File;
using Health_Insurance.Domain.Extensions;
using Health_Insurance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Health_Insurance.Application.EntityServices;

public class InsuranceRequestEntityService : BaseEntityService<InsuranceRequest>, IInsuranceRequestEntityService
{
    private readonly IPremiumCalculateService _premiumCalculateService;
    private readonly HealthInsuranceDbContext _context;
    public InsuranceRequestEntityService(
        HealthInsuranceDbContext context,
        IPremiumCalculateService premiumCalculateService) : base(context)
    {
        _context = context;
        _premiumCalculateService = premiumCalculateService;
    }

    public async Task<ReturnResult<bool>> AddInsuranceRequestAsync(InsuranceRequestDto insuranceRequest, CancellationToken cancellation = default)
    {
        var result = new ReturnResult<bool>();
        var coverages = await _context.Coverages
            .AsNoTracking()
            .ToListAsync(cancellation);
        var requestCoverages = coverages
            .Where(x => insuranceRequest.CoverageIds.Distinct().Contains(x.Id));
        if (coverages.IsNullOrEmpty())
        {
            return result.UnSuccessResult("هر درخواست باید حداقل یک پوشش را داشته باشد");
        }

        if (!InsuranceRequest.CheckCapitalValidity(capital: insuranceRequest.Capital, coverages: coverages))
        {
            return result.UnSuccessResult("مقدار وارد شده در این فیلد باید در محدوده حداقل و حداکثر سرمایه تعیین شده باشد");
        }
        var totalPremium = await _premiumCalculateService.CalculateTotalPremiumAsync(capital: insuranceRequest.Capital,
           requestCoverages: requestCoverages.Select(x => x.Id));
        var created = await CreateAsync(new InsuranceRequest()
        {
            Capital = insuranceRequest.Capital,
            Title = insuranceRequest.Title,
            InsuranceRequestCoverages = requestCoverages.Select(x => new InsuranceRequestCoverage()
            {
                CoverageId = x.Id,
            }).ToList(),
            TotalPremium = totalPremium
        });
        return created ? result.SuccessResult(created) : result.UnSuccessResult("error in created");
    }

    public async Task<ReturnResult<GetInsuranceRequestPagedListModel>> GetInsuranceRequestListAsync(GetInsuranceRequestParameters parameters,
        CancellationToken cancellation = default)
    {
        var data = new ReturnResult<GetInsuranceRequestPagedListModel>()
        {
            Result = new GetInsuranceRequestPagedListModel()
        };
        var query =  _context.InsuranceRequests
            .AsNoTracking()
            .Where(item => !parameters.Id.HasValue || parameters.Id.Value == item.Id)
            .Where(item => !parameters.Capital.HasValue || parameters.Capital.Value == item.Capital)
            .Where(item => string.IsNullOrEmpty(parameters.Title) || parameters.Title.Contains(item.Title))
            .Select(x => new GetInsuranceRequestListDto()
            {
                Id = x.Id,
                Capital = x.Capital,
                Title = x.Title,
                TotalPremium = x.TotalPremium
            });
        data.Result.TotalRow = await query.CountAsync(cancellation);

        data.Result.Results = await query
            .OrderByDescending(x => x.Id)
            .Skip(parameters.PageSize * (parameters.PageNumber - 1))
            .Take(parameters.PageSize)
            .ToListAsync(cancellation);

        return data.SuccessResult(data.Result);
    }
}