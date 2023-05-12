using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityMigration.Configurations
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
