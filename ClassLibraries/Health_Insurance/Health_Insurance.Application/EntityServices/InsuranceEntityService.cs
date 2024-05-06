using AutoMapper;
using Health_Insurance.Data;
using Health_Insurance.Data.EntityFramework.Contexts;
using Health_Insurance.Domain.Entities.Base;
using Health_Insurance.Domain.Entities.InsuranceTreatment;

namespace Health_Insurance.Application.EntityServices;

public class InsuranceEntityService : BaseEntityService<InsuranceEntity>, IInsuranceEntityService
{
    private readonly IMapper _mapper;
    public InsuranceEntityService(
        DataContext context,
        IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }
}