using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NjordinSight.EntityModel.Context.Configurations
{
    public class AccountObjectConfiguration : IEntityTypeConfiguration<AccountObject>
    {
        private IEnumerable<AccountObject> AccountObjects { get; } = new AccountObject[]
        {

        };

        public void Configure(EntityTypeBuilder<AccountObject> builder)
        {
            throw new NotImplementedException();
        }
    }
}
