﻿using Health_Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance.Data.EntityFramework.Contexts
{
    public class HealthInsuranceDbContext : BaseDbContext
    {
        public HealthInsuranceDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<InsuranceRequest> InsuranceRequests { get; set; }
    }
}
