namespace Health_Insurance.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("InsuranceRequests")]
public class InsuranceRequest: BaseEntity<long>
{
    public InsuranceRequest()
    {
        Coverages = new List<Coverage>();
    }

    [Required]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    public List<Coverage> Coverages { get; set; }

    [Required]
    public decimal Amount { get; set; }

    public decimal TotalPremium { get; set; }
}