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
                new(){ AttributeId = -10, DisplayName = "Asset Class" },
                new(){ AttributeId = -20, DisplayName = "Security Type Group" },
                new(){ AttributeId = -30, DisplayName = "Security Type" },
                new(){ AttributeId = -40, DisplayName = "Broker Transaction Category" },
                new(){ AttributeId = -50, DisplayName = "Broker Transaction Class" }
            };

            ModelAttributeScopes = ModelAttributes
                    .Where(a => a.AttributeId is <= -10 and >= -30)
                    .Select(a => new ModelAttributeScope(
                        attributeId: a.AttributeId,
                        scopeCode: ModelAttributeScopeCode.Security.ConvertToStringCode()))
                    .Concat(
                        ModelAttributes.Where(a => a.AttributeId is <= -40 and >= -41)
                        .Select(a => new ModelAttributeScope()
                        {
                            AttributeId = a.AttributeId,
                            ScopeCode = ModelAttributeScopeCode.BrokerTransactionCode.ConvertToStringCode()
                        }))
                    .ToArray();

            #endregion

            ModelAttributeMember[] brokerTransactionAttributes =
            {
                // Transaction categories
                new(){ AttributeMemberId = -401, AttributeId = -40, DisplayName = "Interest Charge", DisplayOrder = 0 },
                new(){ AttributeMemberId = -402, AttributeId = -40, DisplayName = "Purchases", DisplayOrder = 0 },
                new(){ AttributeMemberId = -403, AttributeId = -40, DisplayName = "Margin Purchases", DisplayOrder = 1 },
                new(){ AttributeMemberId = -404, AttributeId = -40, DisplayName = "Gain/Loss", DisplayOrder = 2 },
                new(){ AttributeMemberId = -405, AttributeId = -40, DisplayName = "Starting Balance", DisplayOrder = 0 },
                new(){ AttributeMemberId = -406, AttributeId = -40, DisplayName = "Contributions", DisplayOrder = 0 },
                new(){ AttributeMemberId = -407, AttributeId = -40, DisplayName = "Withdrawals", DisplayOrder = 1 },
                new(){ AttributeMemberId = -408, AttributeId = -40, DisplayName = "Dividends", DisplayOrder = 0 },
                new(){ AttributeMemberId = -409, AttributeId = -40, DisplayName = "Expenses", DisplayOrder = 2 },
                new(){ AttributeMemberId = -410, AttributeId = -40, DisplayName = "Writeoffs", DisplayOrder = 0 },
                new(){ AttributeMemberId = -411, AttributeId = -40, DisplayName = "Interest", DisplayOrder = 1 },
                new(){ AttributeMemberId = -412, AttributeId = -40, DisplayName = "Principal Pay-Down", DisplayOrder = 1 },
                new(){ AttributeMemberId = -413, AttributeId = -40, DisplayName = "Sales", DisplayOrder = 3 },
                new(){ AttributeMemberId = -414, AttributeId = -40, DisplayName = "Margin Sales", DisplayOrder = 2 },

                // Transaction classes
                new(){ AttributeMemberId =-501, AttributeId = -50, DisplayName = "Expense", DisplayOrder = 4 },
                new(){ AttributeMemberId =-502, AttributeId = -50, DisplayName = "Trade", DisplayOrder = 1 },
                new(){ AttributeMemberId =-503, AttributeId = -50, DisplayName = "Income", DisplayOrder = 2 },
                new(){ AttributeMemberId =-504, AttributeId = -50, DisplayName = "Balance", DisplayOrder = 0 },
                new(){ AttributeMemberId =-505, AttributeId = -50, DisplayName = "Transfer", DisplayOrder = 3 },
                new(){ AttributeMemberId =-506, AttributeId = -50, DisplayName = "Writeoff", DisplayOrder = 5 },
            };

            #region Security types, type groups, asset class, and broker transaction attribute members
            ModelAttributeMember[] assetClasses =
            {
                new(){ AttributeMemberId = -100, AttributeId = -10, DisplayName = "Equities", DisplayOrder = 0 },
                new(){ AttributeMemberId = -101, AttributeId = -10, DisplayName = "Fixed Income", DisplayOrder = 1 },
                new(){ AttributeMemberId = -102, AttributeId = -10, DisplayName = "Derivatives", DisplayOrder = 2 },
                new(){ AttributeMemberId = -103, AttributeId = -10, DisplayName = "Other", DisplayOrder = 3 },
                new(){ AttributeMemberId = -104, AttributeId = -10, DisplayName = "Cash & Equivalents", DisplayOrder = 4 },
                new(){ AttributeMemberId = -105, AttributeId = -10, DisplayName = "Blended Funds & Products", DisplayOrder = 5 },
                new(){ AttributeMemberId = -106, AttributeId = -10, DisplayName = "Debt & Liability", DisplayOrder = 6 },
                new(){ AttributeMemberId = -107, AttributeId = -10, DisplayName = "Not Classified", DisplayOrder = 7 },
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
                .Concat(brokerTransactionAttributes)
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

            #region Broker transaction codes and categorizations
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

            BrokerTransactionCodeAttributes = new BrokerTransactionCodeAttributeMemberEntry[]
            {
                // Transaction category attribute assignment
                new(){ AttributeMemberId = -401, TransactionCodeId = -25, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -402, TransactionCodeId = -11, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -403, TransactionCodeId = -10, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -404, TransactionCodeId = -26, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -405, TransactionCodeId = -23, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -406, TransactionCodeId = -17, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -407, TransactionCodeId = -18, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -406, TransactionCodeId = -12, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -408, TransactionCodeId = -13, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -409, TransactionCodeId = -14, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -410, TransactionCodeId = -15, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -411, TransactionCodeId = -16, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -412, TransactionCodeId = -19, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -406, TransactionCodeId = -24, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -414, TransactionCodeId = -20, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -407, TransactionCodeId = -21, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -407, TransactionCodeId = -22, EffectiveDate = DateTime.MinValue, Weight = 1M },

                // Transaction class attribute assignment
                new(){ AttributeMemberId = -501, TransactionCodeId = -25, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -502, TransactionCodeId = -11, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -502, TransactionCodeId = -10, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -503, TransactionCodeId = -26, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -504, TransactionCodeId = -23, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -505, TransactionCodeId = -17, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -505, TransactionCodeId = -18, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -505, TransactionCodeId = -12, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -503, TransactionCodeId = -13, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -501, TransactionCodeId = -14, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -506, TransactionCodeId = -15, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -503, TransactionCodeId = -16, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -503, TransactionCodeId = -19, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -505, TransactionCodeId = -24, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -502, TransactionCodeId = -20, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -502, TransactionCodeId = -21, EffectiveDate = DateTime.MinValue, Weight = 1M },
                new(){ AttributeMemberId = -505, TransactionCodeId = -22, EffectiveDate = DateTime.MinValue, Weight = 1M }
            };
            #endregion 

            #region Market Holiday information
            MarketHolidays = new MarketHoliday[]
            {
                new(){ MarketHolidayId = -10, MarketHolidayName = "Christmas Day" },
                new(){ MarketHolidayId = -11, MarketHolidayName = "Good Friday" },
                new(){ MarketHolidayId = -12, MarketHolidayName = "Independence Day" },
                new(){ MarketHolidayId = -13, MarketHolidayName = "Labor Day" },
                new(){ MarketHolidayId = -14, MarketHolidayName = "Martin Luther King, Jr. Day" },
                new(){ MarketHolidayId = -15, MarketHolidayName = "Memorial Day" },
                new(){ MarketHolidayId = -16, MarketHolidayName = "New Years Day" },
                new(){ MarketHolidayId = -17, MarketHolidayName = "President's Day" },
                new(){ MarketHolidayId = -18, MarketHolidayName = "Thanksgiving Day" }
            };

            MarketHolidayObservances = new MarketHolidayObservance[]
            {
                new(){ MarketHolidayId = -10, ObservanceDate = new(2022, 12, 16) },
                new(){ MarketHolidayId = -11, ObservanceDate = new(2022, 4, 15) },
                new(){ MarketHolidayId = -12, ObservanceDate = new(2022, 7, 4) },
                new(){ MarketHolidayId = -13, ObservanceDate = new(2022, 9, 5) },
                new(){ MarketHolidayId = -14, ObservanceDate = new(2022, 1, 17) },
                new(){ MarketHolidayId = -15, ObservanceDate = new(2022, 5, 30) },
                new(){ MarketHolidayId = -16, ObservanceDate = new(2022, 1, 1) },
                new(){ MarketHolidayId = -17, ObservanceDate = new(2022, 2, 21) },
                new(){ MarketHolidayId = -18, ObservanceDate = new(2022, 11, 24) }
            };
            #endregion
        }

        /// <summary>
        /// Gets the <see cref="BrokerTransactionCode"/> seed models.
        /// </summary>
        public BrokerTransactionCode[] BrokerTransactionCodes { get; }

        /// <summary>
        /// Gets the <see cref="BrokerTransactionCodeAttributeMemberEntry"/> seed models.
        /// </summary>
        public BrokerTransactionCodeAttributeMemberEntry[] BrokerTransactionCodeAttributes { get; }

        /// <summary>
        /// Gets the <see cref="MarketHoliday"/> seed models.
        /// </summary>
        public MarketHoliday[] MarketHolidays { get; }

        /// <summary>
        /// Gets the <see cref="MarketHolidayObservance"/> seed models.
        /// </summary>
        public MarketHolidayObservance[] MarketHolidayObservances { get; }

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
    }
}
