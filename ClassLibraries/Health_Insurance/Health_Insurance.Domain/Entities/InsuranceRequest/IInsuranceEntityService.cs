
using Health_Insurance.Domain.Entities.Base;
using Health_Insurance.Domain.Entities.File;
using Health_Insurance.Domain.Models;

namespace Health_Insurance.Domain.Entities;

public interface IInsuranceRequestEntityService : IBaseEntityService<InsuranceRequest>
{
    Task<ReturnResult<bool>> AddInsuranceRequestAsync(InsuranceRequestDto insuranceRequest, CancellationToken cancellation = default);
    Task<ReturnResult<GetInsuranceRequestPagedListModel>> GetInsuranceRequestListAsync(GetInsuranceRequestParameters parameters,
        CancellationToken cancellation = default);
}