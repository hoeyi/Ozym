using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModel.Context
{
    /// <summary>
    /// Derived <see cref="FinanceDbContext"/> that represents a relational-database specific 
    /// implementation of the data model.
    /// </summary>
    public class FinanceDbContextSql : FinanceDbContext
    {
        public FinanceDbContextSql()
        {
        }

        public FinanceDbContextSql(DbContextOptions<FinanceDbContext> options)
            : base(options)
        {
        }

        protected override bool UseRelationalDatabase => true;
    }
}
