using NjordFinance.ModelMetadata;
using System;
using System.Linq;
using NjordFinance.Model;

namespace NjordFinance.Context.Configuration
{
    /// <summary>
    /// Represents the seed data and settings for development and production versions of
    /// <see cref="FinanceDbContext"/>.
    /// <list type="bullet">Includes models for the following:
    /// <item><see cref="ModelAttribute"/></item>
    /// <item><see cref="ModelAttributeScope"/></item>
    /// <item><see cref="ModelAttributeMember"/></item>
    /// <item><see cref="SecurityTypeGroup"/></item>
    /// <item><see cref="SecurityType"/></item>
    /// <item><see cref="SecuritySymbolType"/></item>
    /// </list>
    /// Items are listed in the order they should be created.
    /// </summary>
    internal class DefaultReferenceDataModel
    {
        /// <summary>
        /// Creates a new instance of <see cref="DefaultReferenceDataModel"/>.
        /// </summary>
        public DefaultReferenceDataModel()
        {
            ModelAttributes = new ModelAttribute[]
            {
                    new(attributeId: -1, displayName: "AssetClass"),
                    new(attributeId: -2, displayName: "Security Type Group"),
                    new(attributeId: -3, displayName: "SecurityType")
            };

            ModelAttributeScopes = ModelAttributes
                    .Where(a => a.AttributeId is < 0 and > -4)
                    .Select(a => new ModelAttributeScope(
                        attributeId: a.AttributeId,
                        scopeCode: AttributeScopeCode.Security.ConvertToStringCode()))
                    .ToArray();

            ModelAttributeMember[] assetClasses =
            {
                new(attributeMemberId: -10, attributeId: -1, displayName: "Equities", displayOrder: 0),
                new(attributeMemberId: -11, attributeId: -1, displayName: "Fixed Income", displayOrder: 1),
                new(attributeMemberId: -12, attributeId: -1, displayName: "Derivatives", displayOrder: 2),
                new(attributeMemberId: -13, attributeId: -1, displayName: "Other", displayOrder: 3),
                new(attributeMemberId: -14, attributeId: -1, displayName: "Cash & Equivalents", displayOrder: 4),
                new(attributeMemberId: -15, attributeId: -1, displayName: "Blended Funds & Products", displayOrder: 5),
                new(attributeMemberId: -16, attributeId: -1, displayName: "Debt & Liability", displayOrder: 6),
                new(attributeMemberId: -17, attributeId: -1, displayName: "Not classified", displayOrder: 7)
            };

            SecurityTypeGroups = new SecurityTypeGroup[]
            {
                new(-200, "Individual Stocks", -200),
                new(-201, "Equity Funds & ETFs", -201),
                new(-202, "Individual Bonds & CDs", -202),
                new(-203, "Fixed Income Funds & ETFs", -203),
                new(-204, "Option Contracts", -204),
                new(-205, "Digital Assets", -205),
                new(-206, "Other Funds & ETPs", -206),
                new(-207, "Short-Term Debt", -207),
                new(-208, "Long-Term Debt", -208),
                new(-209, "Cash Funds & Currency", -209),
                new(-210, "Cash Deposit", -210),
                new(-211, "Expense", -211),
                new(-212, "Not Classified", -212)
            };

            SecurityTypes = new SecurityType[]
            {
                new(-300, -200, "Common Stock", 1M, true, true, -300),
                new(-301, -200, "American Depository Receipt", 1M, true, true, -301),
                new(-302, -201, "Equity ETF", 1M, true, true, -302),
                new(-303, -201, "Equity Mutual Fund", 1M, true, false, -303),
                new(-304, -202, "Corporate Bonds", 0.01M, true, false, -304),
                new(-305, -202, "Municipal Bonds", 0.01M, true, false, -305),
                new(-306, -202, "U.S. Government Bonds & Bills", 0.1M, true, false, -306),
                new(-307, -202, "Certificate of Deposit", 1M, true, false, -307),
                new(-308, -203, "Bond ETF", 1M, true, true, -308),
                new(-309, -203, "Bond Mutual Fund", 1M, true, false, -309),
                new(-310, -204, "Call Option", 100M, true, false, -310),
                new(-311, -204, "Put Option", 100M, true, false, -311),
                new(-312, -205, "Cryptocurrency", 1M, true, false, -312),
                new(-313, -206, "Exchange-Traded Note", 1M, true, false, -313),
                new(-314, -206, "Retirement Plan", 1M, true, false, -314),
                new(-315, -207, "Revolving Debt", -1M, true, false, -315),
                new(-316, -208, "Student Debt", -1M, true, false, -316),
                new(-317, -209, "Money-Market Fund", 1M, true, false, -317),
                new(-318, -209, "Foreign Currency", 1M, true, false, -318),
                new(-319, -210, "Cash", 1M, true, false, -319),
                new(-320, -211, "Expense", 0M, false, false, -320),
                new(-321, -212, "None/External", 0M, false, false, -321)
            };

            ModelAttributeMembers = assetClasses
                .Concat(SecurityTypeGroups.Select(s => new ModelAttributeMember
                {
                    AttributeId = -2,
                    AttributeMemberId = s.SecurityTypeGroupId,
                    DisplayName = s.SecurityTypeGroupName,
                    DisplayOrder = (short)Array.IndexOf(SecurityTypeGroups, s)
                }))
                .Concat(SecurityTypes.Select(s => new ModelAttributeMember()
                {
                    AttributeId = -3,
                    AttributeMemberId = s.SecurityTypeId,
                    DisplayName = s.SecurityTypeName,
                    DisplayOrder = (short)Array.IndexOf(SecurityTypes, s)
                }))
                .ToArray();

            SecuritySymbolTypes = new SecuritySymbolType[]
            {
                new() { SymbolTypeId = -10, SymbolTypeName = "CUSIP" },
                new() { SymbolTypeId = -20, SymbolTypeName = "Custom Identifier" },
                new() { SymbolTypeId = -30, SymbolTypeName = "Option Ticker" },
                new() { SymbolTypeId = -40, SymbolTypeName = "Ticker" }
            };
        }

        /// <summary>
        /// Gets the <see cref="ModelAttribute"/> seed models.
        /// </summary>
        public ModelAttribute[] ModelAttributes { get; init; }

        /// <summary>
        /// Gets the <see cref="ModelAttributeScope"/> seed models.
        /// </summary>
        public ModelAttributeScope[] ModelAttributeScopes { get; init; }

        /// <summary>
        /// Gets the <see cref="ModelAttributeMember"/> seed models.
        /// </summary>
        public ModelAttributeMember[] ModelAttributeMembers { get; init; }

        /// <summary>
        /// Gets the <see cref="SecurityTypeGroup"/> seed models.
        /// </summary>
        public SecurityTypeGroup[] SecurityTypeGroups { get; init; }

        /// <summary>
        /// Gets the <see cref="SecurityType"/> seed models.
        /// </summary>
        public SecurityType[] SecurityTypes { get; init; }

        /// <summary>
        /// Gets the <see cref="SecuritySymbolType"/> seed models.
        /// </summary>
        public SecuritySymbolType[] SecuritySymbolTypes { get; init; }
    }
}
