using Microsoft.EntityFrameworkCore;
using NjordFinance.Context.Configuration;
using NjordFinance.Model;
using System;
using System.Linq;

namespace NjordFinance.Context
{
    public partial class FinanceDbContext : DbContext
    {
        private readonly ISeedData _seedData;

        /// <summary>
        /// Initializes a new <see cref="FinanceDbContext"/> instance populated with the 
        /// given seed data.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="seedData"></param>
        internal FinanceDbContext(
            DbContextOptions<FinanceDbContext> options,
            ISeedData seedData)
            : base(options)
        {
            _seedData = seedData;
        }
        /// <summary>
        /// Handles additional configuration steps for the <see cref="FinanceDbContext"/> 
        /// model.
        /// </summary>
        /// <param name="modelBuilder"></param>
#pragma warning disable CA1822 // Mark members as static
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
#pragma warning restore CA1822 // Mark members as static
        {
            modelBuilder.SeedDefaultReferenceData();

            if(_seedData is not null)
                modelBuilder.SeedInitialData(_seedData);
        }
    }
} 
