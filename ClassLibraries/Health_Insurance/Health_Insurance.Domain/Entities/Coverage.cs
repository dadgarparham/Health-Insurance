namespace Health_Insurance.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Coverage
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public Int16 CoverageType { get; set; }

    [Required]
    public decimal MinimumAmount { get; set; }

    [Required]
    public decimal MaximumAmount { get; set; }

    // public List<RequestInsurance> RequestsInsurance { get; set; }
}