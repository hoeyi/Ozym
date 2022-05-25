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
    /// <item><see cref="BrokerTransactionCode"/></item>
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
            #region Model attributes and scope
            ModelAttributes = new ModelAttribute[]
            {
                    new(attributeId: -10, displayName: "AssetClass"),
                    new(attributeId: -20, displayName: "Security Type Group"),
                    new(attributeId: -30, displayName: "SecurityType")
            };

            ModelAttributeScopes = ModelAttributes
                    .Where(a => a.AttributeId is <= -10 and >= -30)
                    .Select(a => new ModelAttributeScope(
                        attributeId: a.AttributeId,
                        scopeCode: ModelAttributeScopeCode.Security.ConvertToStringCode()))
                    .ToArray();

            #endregion

            #region Security types, type groups, and asset class attribute members
            ModelAttributeMember[] assetClasses =
            {
                new(attributeMemberId: -100, attributeId: -10, displayName: "Equities", displayOrder: 0),
                new(attributeMemberId: -101, attributeId: -10, displayName: "Fixed Income", displayOrder: 1),
                new(attributeMemberId: -102, attributeId: -10, displayName: "Derivatives", displayOrder: 2),
                new(attributeMemberId: -103, attributeId: -10, displayName: "Other", displayOrder: 3),
                new(attributeMemberId: -104, attributeId: -10, displayName: "Cash & Equivalents", displayOrder: 4),
                new(attributeMemberId: -105, attributeId: -10, displayName: "Blended Funds & Products", displayOrder: 5),
                new(attributeMemberId: -106, attributeId: -10, displayName: "Debt & Liability", displayOrder: 6),
                new(attributeMemberId: -107, attributeId: -10, displayName: "Not classified", displayOrder: 7)
            };

            SecurityTypeGroups = new SecurityTypeGroup[]
            {
                new(-200, "Individual Stocks"),
                new(-201, "Equity Funds & ETFs"),
                new(-202, "Individual Bonds & CDs"),
                new(-203, "Fixed Income Funds & ETFs"),
                new(-204, "Option Contracts"),
                new(-205, "Digital Assets"),
                new(-206, "Other Funds & ETPs"),
                new(-207, "Short-Term Debt"),
                new(-208, "Long-Term Debt"),
                new(-209, "Cash Funds & Currency"),
                new(-210, "Cash Deposit"),
                new(-211, "Expense"),
                new(-212, "Not Classified")
            };

            SecurityTypes = new SecurityType[]
            {
                new(-300, -200, "Common Stock", 1M, true, true),
                new(-301, -200, "American Depository Receipt", 1M, true, true),
                new(-302, -201, "Equity ETF", 1M, true, true),
                new(-303, -201, "Equity Mutual Fund", 1M, true, false),
                new(-304, -202, "Corporate Bonds", 0.01M, true, false),
                new(-305, -202, "Municipal Bonds", 0.01M, true, false),
                new(-306, -202, "U.S. Government Bonds & Bills", 0.1M, true, false),
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
                    AttributeId = -20,
                    AttributeMemberId = s.SecurityTypeGroupId,
                    DisplayName = s.SecurityTypeGroupName,
                    DisplayOrder = (short)Array.IndexOf(SecurityTypeGroups, s)
                }))
                .Concat(SecurityTypes.Select(s => new ModelAttributeMember()
                {
                    AttributeId = -30,
                    AttributeMemberId = s.SecurityTypeId,
                    DisplayName = s.SecurityTypeName,
                    DisplayOrder = (short)Array.IndexOf(SecurityTypes, s)
                }))
                .ToArray();
            #endregion

            #region Security symbol type
            SecuritySymbolTypes = new SecuritySymbolType[]
            {
                new() { SymbolTypeId = -10, SymbolTypeName = "CUSIP" },
                new() { SymbolTypeId = -20, SymbolTypeName = "Custom Identifier" },
                new() { SymbolTypeId = -30, SymbolTypeName = "Option Ticker" },
                new() { SymbolTypeId = -40, SymbolTypeName = "Ticker" }
            };
            #endregion

            BrokerTransactionCodes = new BrokerTransactionCode[]
            {
                new() 
                { 
                    TransactionCodeId = -10,
                    TransactionCode = "btc", 
                    DisplayName = "Buy to cover", 
                    CashEffect = -1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = 1 
                },
                new() 
                {
                    TransactionCodeId = -11,
                    TransactionCode = "buy", 
                    DisplayName = "Buy", 
                    CashEffect = -1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = 1 
                },
                new() 
                {
                    TransactionCodeId = -12,
                    TransactionCode = "dep", 
                    DisplayName = "Deposit", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 1, 
                    QuantityEffect = 0 
                },
                new() 
                {
                    TransactionCodeId = -13,
                    TransactionCode = "div", 
                    DisplayName = "Dividend", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = 0 
                },
                new() 
                {
                    TransactionCodeId = -14,
                    TransactionCode = "exp", 
                    DisplayName = "Expense", 
                    CashEffect = -1, 
                    ContributionWithdrawalEffect = -1, 
                    QuantityEffect = 0 
                },
                new() 
                {
                    TransactionCodeId = -15,
                    TransactionCode = "frt", 
                    DisplayName = "Forfeit shares", 
                    CashEffect = 0, 
                    ContributionWithdrawalEffect = -1, 
                    QuantityEffect = -1 
                },
                new() 
                {
                    TransactionCodeId = -16,
                    TransactionCode = "int", 
                    DisplayName = "Interest", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = 0 
                },
                new() 
                {
                    TransactionCodeId = -17,
                    TransactionCode = "dli", 
                    DisplayName = "Deliver-in", 
                    CashEffect = 0, 
                    ContributionWithdrawalEffect = 1, 
                    QuantityEffect = 1 
                },
                new() 
                {
                    TransactionCodeId = -18,
                    TransactionCode = "dlo", 
                    DisplayName = "Deliver-out", 
                    CashEffect = 0, 
                    ContributionWithdrawalEffect = -1, 
                    QuantityEffect = -1 
                },
                new() 
                {
                    TransactionCodeId = -19,
                    TransactionCode = "pdn", 
                    DisplayName = "Pay-down", 
                    CashEffect = -1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = -1 
                },
                new() 
                {
                    TransactionCodeId = -20,
                    TransactionCode = "sll", 
                    DisplayName = "Sale", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = -1 
                },
                new() 
                {
                    TransactionCodeId = -21,
                    TransactionCode = "ssl", 
                    DisplayName = "Short sale", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = -1 
                },
                new()
                {
                    TransactionCodeId = -22,
                    TransactionCode = "wth", 
                    DisplayName = "Withdrawal", 
                    CashEffect = -1, 
                    ContributionWithdrawalEffect = -1, 
                    QuantityEffect = 0 
                },
                new() 
                {
                    TransactionCodeId = -23,
                    TransactionCode = "chn", 
                    DisplayName = "Change in value", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 1, 
                    QuantityEffect = 1 
                },
                new() 
                {
                    TransactionCodeId = -24,
                    TransactionCode = "plc", 
                    DisplayName = "Plan contribution", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 1, 
                    QuantityEffect = 0 
                },
                new() 
                {
                    TransactionCodeId = -25,
                    TransactionCode = "ain", 
                    DisplayName = "Accrued interest", 
                    CashEffect = -1, 
                    ContributionWithdrawalEffect = -1, 
                    QuantityEffect = 0 
                },
                new() 
                {
                    TransactionCodeId = -26,
                    TransactionCode = "cap", 
                    DisplayName = "Capital return", 
                    CashEffect = 1, 
                    ContributionWithdrawalEffect = 0, 
                    QuantityEffect = 0 
                }
            };
        }

        /// <summary>
        /// Gets the <see cref="ModelAttribute"/> seed models.
        /// </summary>
        public ModelAttribute[] ModelAttributes { get; }

        /// <summary>
        /// Gets the <see cref="ModelAttributeScope"/> seed models.
        /// </summary>
        public ModelAttributeScope[] ModelAttributeScopes { get; }

        /// <summary>
        /// Gets the <see cref="ModelAttributeMember"/> seed models.
        /// </summary>
        public ModelAttributeMember[] ModelAttributeMembers { get; }

        /// <summary>
        /// Gets the <see cref="SecurityTypeGroup"/> seed models.
        /// </summary>
        public SecurityTypeGroup[] SecurityTypeGroups { get; }

        /// <summary>
        /// Gets the <see cref="SecurityType"/> seed models.
        /// </summary>
        public SecurityType[] SecurityTypes { get; }

        /// <summary>
        /// Gets the <see cref="SecuritySymbolType"/> seed models.
        /// </summary>
        public SecuritySymbolType[] SecuritySymbolTypes { get; }

        /// <summary>
        /// Gets the <see cref="BrokerTransactionCode"/> seed models.
        /// </summary>
        public BrokerTransactionCode[] BrokerTransactionCodes { get; }
    }
}
