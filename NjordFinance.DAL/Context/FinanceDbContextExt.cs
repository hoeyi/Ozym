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
            modelBuilder.SeedModelReferenceData();
        }

        private static DateTime GetRandomDateTime(int minimumYearSeed, int maximumYearSeed)
        {
            Random random = new();

            return DateTime.Now
                .AddYears(
                    random.Next(
                        minValue: minimumYearSeed < 0 ? 0 : minimumYearSeed, 
                        maxValue: maximumYearSeed > 25 ? 25 : maximumYearSeed) * -1)
                .AddMonths(random.Next(0, 12))
                .AddDays(random.Next(0, 30));
        }
    }
}
