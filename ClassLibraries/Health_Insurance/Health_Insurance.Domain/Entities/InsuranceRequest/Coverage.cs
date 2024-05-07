namespace Health_Insurance.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Coverages")]
public class Coverage: BaseEntity<byte>
{
    public Coverage()
    {
        InsuranceRequestCoverages = new List<InsuranceRequestCoverage>();
    }
    [Required]
    [StringLength(50)]
    public string Title { get; set; } = null!;

    [Required]
    public decimal MinimumAmount { get; set; }

    [Required]
    public decimal MaximumAmount { get; set; }

    [Required]
    public float PremiumCoefficient { get; set; }

    public List<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; }
}