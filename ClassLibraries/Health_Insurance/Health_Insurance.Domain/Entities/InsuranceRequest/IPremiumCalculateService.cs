namespace Health_Insurance.Domain.Entities;
public interface IPremiumCalculateService
{
   Task<decimal> CalculateTotalPremiumAsync(decimal capital, IEnumerable<byte> requestCoverages,
       CancellationToken cancellationToken = default);
}
