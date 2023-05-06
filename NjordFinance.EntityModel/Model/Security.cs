using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NjordFinance.EntityModel.Metadata;

namespace NjordFinance.EntityModel
{
    [Table("Security", Schema = "FinanceApp")]
    [Index(nameof(SecurityExchangeId), Name = "IX_Security_SecurityExchangeID")]
    [Index(nameof(SecurityTypeId), Name = "IX_Security_SecurityTypeID")]
    public partial class Security
    {
        public Security()
        {
            AccountWallets = new HashSet<AccountWallet>();
            BrokerTransactionDepSecurities = new HashSet<BrokerTransaction>();
            BrokerTransactionSecurities = new HashSet<BrokerTransaction>();
            SecurityAttributeMemberEntries = new HashSet<SecurityAttributeMemberEntry>();
            SecurityPrices = new HashSet<SecurityPrice>();
            SecuritySymbols = new HashSet<SecuritySymbol>();
        }

        [Key]
        [Column("SecurityID")]
        public int SecurityId { get; set; }
        [Column("SecurityTypeID")]
        public int SecurityTypeId { get; set; }
        [Column("SecurityExchangeID")]
        public int? SecurityExchangeId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string SecurityDescription { get; set; }
        [StringLength(96,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string Issuer { get; set; }
        public bool HasPerpetualMarket { get; set; }
        public bool HasPerpetualPrice { get; set; }

        [ForeignKey(nameof(SecurityExchangeId))]
        [InverseProperty("Securities")]
        public virtual SecurityExchange SecurityExchange { get; set; }
        [ForeignKey(nameof(SecurityTypeId))]
        [InverseProperty("Securities")]
        public virtual SecurityType SecurityType { get; set; }
        [InverseProperty(nameof(AccountWallet.DenominationSecurity))]
        public virtual ICollection<AccountWallet> AccountWallets { get; set; }
        [InverseProperty(nameof(BrokerTransaction.DepSecurity))]
        public virtual ICollection<BrokerTransaction> BrokerTransactionDepSecurities { get; set; }
        [InverseProperty(nameof(BrokerTransaction.Security))]
        public virtual ICollection<BrokerTransaction> BrokerTransactionSecurities { get; set; }
        [InverseProperty(nameof(SecurityAttributeMemberEntry.Security))]
        public virtual ICollection<SecurityAttributeMemberEntry> SecurityAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(SecurityPrice.Security))]
        public virtual ICollection<SecurityPrice> SecurityPrices { get; set; }
        [InverseProperty("Security")]
        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
