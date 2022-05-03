using Microsoft.EntityFrameworkCore;

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
