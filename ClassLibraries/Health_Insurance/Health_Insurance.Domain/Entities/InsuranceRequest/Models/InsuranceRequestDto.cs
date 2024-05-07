namespace Health_Insurance.Domain.Models;
public class InsuranceRequestDto
{
    public string Title { get; set; } = null!;

    public List<byte> CoverageIds { get; set; } = new();

    public decimal Capital { get; set; }

}