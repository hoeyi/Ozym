using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NjordinSight.EntityModel.Context.Configurations
{
    public class AccountCustodianConfiguration : IEntityTypeConfiguration<AccountCustodian>
    {
        public void Configure(EntityTypeBuilder<AccountCustodian> builder)
        {
            var accountCustodians = new AccountCustodian[]
            {
                new(){ AccountCustodianId = -1, CustodianCode = "SOMEWHERE", DisplayName = "SomeWhere Bank LLC" },
                new(){ AccountCustodianId = -2, CustodianCode = "SOMENAME", DisplayName = "Some Name Securities Broker" },
                new(){ AccountCustodianId = -3, CustodianCode = "CRYPTO", DisplayName = "Cryptopotamus Coin Exchange" },
                new(){ AccountCustodianId = -4, CustodianCode = "TESTDELPASS", DisplayName = "Test delete pass" },
                new(){ AccountCustodianId = -5, CustodianCode = "TESTUPDATE", DisplayName = "Test update pass" }
            };

            builder.HasData(accountCustodians);
        }
    }
}
