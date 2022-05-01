using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;

namespace NjordFinance.Context
{
    public partial class FinanceDbContext : DbContext
    {
#pragma warning disable CA1822 // Mark members as static
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
#pragma warning restore CA1822 // Mark members as static
        {
            modelBuilder.SeedDefaultReferenceData();

            modelBuilder.SeedTestReferenceData();

            modelBuilder.SeedTestSecurityData();

            modelBuilder.SeedTestAccountData();
        }
    }
}
