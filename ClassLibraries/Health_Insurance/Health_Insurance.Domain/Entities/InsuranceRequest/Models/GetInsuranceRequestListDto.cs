using Health_Insurance.Domain.Entities.File;

namespace Health_Insurance.Domain.Models;
public class GetInsuranceRequestListDto
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Capital { get; set; }
    public decimal TotalPremium { get; set; }
}


public class GetInsuranceRequestPagedListModel : PagedListModel<GetInsuranceRequestListDto>
{

}