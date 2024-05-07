using Health_Insurance.Data.EntityFramework.Contexts;
using Health_Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Health_Insurance.Application;

public class PremiumCalculateService : IPremiumCalculateService
{
    private readonly HealthInsuranceDbContext _context;

    public PremiumCalculateService(HealthInsuranceDbContext context)
    {
        _context = context;
    }
    
    //فقط قراره محاسبه کنه
    public async Task<decimal> CalculateTotalPremiumAsync(decimal capital, IEnumerable<byte> requestCoverages,
       CancellationToken cancellationToken = default)
    {
        var coverages = await _context.Coverages
             .AsNoTracking()
             .ToListAsync(cancellationToken);

        decimal totalPremium = 0;
        foreach (var item in requestCoverages)
        {
            totalPremium += (decimal)coverages.First(x => x.Id == item).PremiumCoefficient * capital;
        }

        return totalPremium;
    }
    
}