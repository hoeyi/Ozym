using NjordFinance.ModelMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.Configuration
{
    /// <summary>
    /// Represents the seed data and settings for development and production versions of
    /// <see cref="Context.FinanceDbContext"/>.
    /// </summary>
    internal class DefaultModel : IModelConfiguration
    {
        /// <summary>
        /// Creates a new instance of <see cref="DefaultModel"/>.
        /// </summary>
        public DefaultModel()
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
                new(securityTypeGroupId: -200, securityTypeGroupName: "Individual Stocks"),
                new(securityTypeGroupId: -201, securityTypeGroupName: "Equity Funds & ETFs"),
                new(securityTypeGroupId: -202, securityTypeGroupName: "Individual Bonds & CDs"),
                new(securityTypeGroupId: -203, securityTypeGroupName: "Fixed Income Funds & ETFs"),
                new(securityTypeGroupId: -204, securityTypeGroupName: "Option Contracts"),
                new(securityTypeGroupId: -205, securityTypeGroupName: "Digital Assets"),
                new(securityTypeGroupId: -206, securityTypeGroupName: "Other Funds & ETPs"),
                new(securityTypeGroupId: -207, securityTypeGroupName: "Short-Term Debt"),
                new(securityTypeGroupId: -208, securityTypeGroupName: "Long-Term Debt"),
                new(securityTypeGroupId: -209, securityTypeGroupName: "Cash Funds & Currency"),
                new(securityTypeGroupId: -210, securityTypeGroupName: "Cash Deposit"),
                new(securityTypeGroupId: -211, securityTypeGroupName: "Expense"),
                new(securityTypeGroupId: -212, securityTypeGroupName: "Not Classified")
            };

            SecurityTypes = new SecurityType[]
            {
                new(-300, -200, "Common Stock", 1M, true, true),
                new(-301, -200, "American Depository Receipt", 1M, true, true),
                new(-302, -201, "Equity ETF", 1M, true, true),
                new(-303, -201, "Equity Mutual Fund", 1M, true, false),
                new(-304, -202, "Corporate Bonds", 1M, true, false),
                new(-305, -202, "Municipal Bonds", 1M, true, false),
                new(-306, -202, "U.S. Government Bonds & Bills", 1M, true, false),
                new(-307, -202, "Certificate of Deposit", 1M, true, false),
                new(-308, -203, "Bond ETF", 1M, true, true),
                new(-309, -203, "Bond Mutual Fund", 1M, true, false),
                new(-310, -204, "Call Option", 100M, true, false),
                new(-311, -204, "Put Option", 100M, true, false),
                new(-312, -205, "Cryptocurrency", 1M, true, false),
                new(-313, -206, "Exchange-Traded Note", 1M, true, false),
                new(-314, -206, "Retirement Plan", 1M, true, false),
                new(-315, -207, "Revolving Debt", -1M, true, false),
                new(-316, -208, "Student Debt", -1M, true, false),
                new(-317, -209, "Money-Market Fund", 1M, true, false),
                new(-318, -209, "Foreign Currency", 1M, true, false),
                new(-319, -210, "Cash", 1M, true, false),
                new(-320, -211, "Expense", 0M, false, false),
                new(-321, -212, "None/External", 0M, false, false)
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

        /// <inheritdoc/>
        public ModelAttribute[] ModelAttributes { get; init; }

        /// <inheritdoc/>
        public ModelAttributeScope[] ModelAttributeScopes { get; init; }

        /// <inheritdoc/>
        public ModelAttributeMember[] ModelAttributeMembers { get; init; }

        /// <inheritdoc/>
        public SecurityTypeGroup[] SecurityTypeGroups { get; init; }

        /// <inheritdoc/>
        public SecurityType[] SecurityTypes { get; init; }

        /// <inheritdoc/>
        public SecuritySymbolType[] SecuritySymbolTypes { get; init; }
    }
}
