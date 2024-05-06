using Health_Insurance.Data;
using Microsoft.EntityFrameworkCore;
using Health_Insurance.Domain.Entities;
using Health_Insurance.Domain.Enums;

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

        switch (request.Coverage.CoverageType)
        {
            case (int)CoverageType.SurgicalCoverage: //جراحی
                totalPremium += request.Amount * 0.0052m;
                break;
            case (int)CoverageType.DentalCoverage: //دندانپزشکی
                totalPremium += request.Amount * 0.0042m;
                break;
            case (int)CoverageType.BedCoverage: //بستری
                totalPremium += request.Amount * 0.005m;
                break;
        }

        request.TotalPremium = totalPremium;
        _context.SaveChanges();

        return totalPremium;
    }
    
}