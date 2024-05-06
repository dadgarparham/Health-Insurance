namespace Health_Insurance.Domain.Entities;
public interface IPremiumCalculateService
{
    Task<decimal> CalculateTotalPremiumAsync(int requestId);
}
