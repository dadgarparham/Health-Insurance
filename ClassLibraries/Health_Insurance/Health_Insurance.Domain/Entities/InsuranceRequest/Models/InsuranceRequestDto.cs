namespace Health_Insurance.Domain.Entities;
public class InsuranceRequestDto
{
    public string Title { get; set; } = null!;

    public List<byte> CoverageIdlist { get; set; } = new();

    public decimal Amount { get; set; }

}