using Health_Insurance.Domain.Entities.Base;

namespace Health_Insurance.Domain.Entities;
public class GetInsuranceRequestParameters:BaseSearchParameters
{
    public long? Id { get; set; }
    public string? Title { get; set; }
    public decimal? Capital { get; set; }
}
