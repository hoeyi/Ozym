using NjordFinance.Model;
using NjordFinance.ModelMetadata;

namespace NjordFinance.Context.Configuration
{
    /// <summary>
    /// Represents the seed data for test versions of account data in <see cref="FinanceDbContext"/>.
    /// <list type="bullet">Includes test models for the following:
    /// <item><see cref="AccountCustodian"/></item>
    /// <item><see cref="AccountObject"/></item>
    /// <item><see cref="Account"/></item>
    /// </list>
    /// Items are listed in the order they should be created.
    /// </summary>
    internal class TestAccountDataModel
    {
        /// <summary>
        /// Creates a new instance of <see cref="TestAccountDataModel"/>.
        /// </summary>
        public TestAccountDataModel()
        {
        }

        /// <summary>
        /// Gets the <see cref="AccountCustodian"/> seed models.
        /// </summary>
        public AccountCustodian[] AccountCustodians { get; } =
        {
            new AccountCustodian()
            {
                AccountCustodianId = -1,
                CustodianCode = "SOMEWHERE",
                DisplayName = "SomeWhere Bank LLC"
            },
            new AccountCustodian()
            {
                AccountCustodianId = -2,
                CustodianCode = "SOMENAME",
                DisplayName = "Some Name Securities Broker"
            },
            new AccountCustodian()
            {
                AccountCustodianId = -3,
                CustodianCode = "CRYPTO",
                DisplayName = "Cryptopotamus Coin Exchange"
            }
        };

        /// <summary>
        /// Gets the <see cref="AccountObject"/> seed models.
        /// </summary>
        public AccountObject[] AccountObjects { get; } =
        {
            new AccountObject()
            {
                AccountObjectId = -1,
                AccountObjectCode = "TESTBROKER",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "Test Broker Account",
                ObjectDescription = "For testing functionality of broker acccount records."
            },
            new AccountObject()
            {
                AccountObjectId = -2,
                AccountObjectCode = "TESTBANK",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "Test Bank Account",
                ObjectDescription = "For testing functionality of bank account records."
            },
            new AccountObject()
            {
                AccountObjectId = -3,
                AccountObjectCode = "TESTCRYPTO",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "Test Crypto Account",
                ObjectDescription = "For testing functionality of crypto broker account records."
            }
        };

        /// <summary>
        /// Gets the <see cref="Account"/> seed models.
        /// </summary>
        public Account[] Accounts { get; } =
        {
            new Account()
            {
                AccountId = -1,
                IsComplianceTradable = true,
                HasBrokerTransaction = true,
                AccountCustodianId = -2
            },
            new Account()
            {
                AccountId = -2,
                IsComplianceTradable = false,
                HasBankTransaction = true,
            },
            new Account()
            {
                AccountId = -3,
                IsComplianceTradable = true,
                HasBrokerTransaction = true,
                HasWallet = true,
                AccountCustodianId = -3
            }
        };
    }
}
