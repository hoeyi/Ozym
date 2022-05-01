using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;

namespace NjordFinance.Context.Configuration
{
    /// <summary>
    /// Represents the seed data for tests versions of reference data in <see cref="FinanceDbContext"/>.
    /// <list type="bullet">Includes models for the following:
    /// <item><see cref="Country"/></item>
    /// </list>
    /// Items are listed in the order they should be created.
    /// </summary>
    internal class TestReferenceDataModel
    {
        /// <summary>
        /// Creates a new instance of <see cref="TestReferenceDataModel"/>.
        /// </summary>
        public TestReferenceDataModel()
        {
        }

        /// <summary>
        /// Gets the <see cref="Country"/> seed models.
        /// </summary>
        public Country[] Countries { get; } =
        {
            new Country()
            {
                CountryId = -1,
                IsoCode3 = "USA",
                DisplayName = "United States of America"
            },
            new Country()
            {
                CountryId = -2,
                IsoCode3 = "DEU",
                DisplayName = "Germany"
            },
            new Country()
            {
                CountryId = -3,
                IsoCode3 = "CAN",
                DisplayName = "Canada"
            },
            new Country()
            {
                CountryId = -4,
                IsoCode3 = "JPN",
                DisplayName = "Japan"
            }
        };
    }
}
