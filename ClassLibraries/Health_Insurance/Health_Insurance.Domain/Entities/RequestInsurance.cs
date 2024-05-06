namespace Health_Insurance.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class RequestInsurance
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    [Required]
    public Coverage Coverage { get; set; }

    [Required]
    public decimal Amount { get; set; }

    public decimal TotalPremium { get; set; }
}