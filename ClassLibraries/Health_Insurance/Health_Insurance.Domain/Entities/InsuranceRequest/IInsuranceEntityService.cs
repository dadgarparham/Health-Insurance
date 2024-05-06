
using Health_Insurance.Domain.Entities.Base;
using Health_Insurance.Domain.Entities.File;

namespace Health_Insurance.Domain.Entities;

public interface IInsuranceRequestEntityService : IBaseEntityService<InsuranceRequest>
{
    Task<ReturnResult<bool>> AddInsuranceRequestAsync(InsuranceRequestDto insuranceRequest, CancellationToken cancellation = default);
    Task<ReturnResult<bool>> GetInsuranceRequestAsync(long id, CancellationToken cancellation = default);
}