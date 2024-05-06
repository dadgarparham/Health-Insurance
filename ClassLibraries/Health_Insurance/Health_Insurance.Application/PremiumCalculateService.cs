using Health_Insurance.Data;
using Microsoft.EntityFrameworkCore;
using Health_Insurance.Domain.Entities;
namespace Health_Insurance.Application;

public class PremiumCalculateService
{
    private readonly HealthInsuranceDbContext _context;

    public PremiumCalculateService(HealthInsuranceDbContext context)
    {
        _context = context;
    }
    
    public decimal CalculateTotalPremium(int requestId)
    {
        var request = _context.RequestsInsurance.Include(r => r.Coverage).FirstOrDefault(r => r.Id == requestId);

        if (request == null)
        {
            throw new ArgumentException("Invalid request ID.");
        }

        decimal totalPremium = 0;

        if (request.Coverage.Name == "جراحی")
        {
            totalPremium += request.Amount * 0.0052m;
        }
        else if (request.Coverage.Name == "دندانپزشکی")
        {
            totalPremium += request.Amount * 0.0042m;
        }
        else if (request.Coverage.Name == "بستری")
        {
            totalPremium += request.Amount * 0.005m;
        }

        request.TotalPremium = totalPremium;
        _context.SaveChanges();

        return totalPremium;
    }
    
}