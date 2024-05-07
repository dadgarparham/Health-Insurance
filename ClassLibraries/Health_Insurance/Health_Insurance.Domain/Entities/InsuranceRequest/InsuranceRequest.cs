namespace Health_Insurance.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("InsuranceRequests")]
public class InsuranceRequest: BaseEntity<long>
{
    public InsuranceRequest()
    {
        InsuranceRequestCoverages = new List<InsuranceRequestCoverage>();
    }

    [Required]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    public List<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; }

    [Required]
    public decimal Capital { get; set; }

    public decimal TotalPremium { get; set; }
    public static bool CheckCapitalValidity(decimal capital, List<Coverage> coverages)
    {
       var minCoverage = coverages.MinBy(x => x.MinimumAmount)!.MinimumAmount;
        var maxCoverage = coverages.MaxBy(x => x.MaximumAmount)!.MaximumAmount;
        return capital >= minCoverage && capital  <= maxCoverage;
    }
}