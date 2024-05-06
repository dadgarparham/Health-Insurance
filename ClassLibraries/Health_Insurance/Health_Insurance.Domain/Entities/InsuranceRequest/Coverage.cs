namespace Health_Insurance.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Coverages")]
public class Coverage: BaseEntity<byte>
{
    public Coverage()
    {
        InsuranceRequests = new HashSet<InsuranceRequest>();
    }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal MinimumAmount { get; set; }

    [Required]
    public decimal MaximumAmount { get; set; }

    public HashSet<InsuranceRequest> InsuranceRequests { get; set; }
}