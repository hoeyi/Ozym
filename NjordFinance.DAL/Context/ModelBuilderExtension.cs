using Microsoft.EntityFrameworkCore;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.Model.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Context
{
    internal static class ModelBuilderExtension
    {
        public static void SeedModelReferenceData(this ModelBuilder modelBuilder)
        {
            #region Model attributes, scopes, and members
            IModelConfiguration defaultModel = new DefaultModel();

            modelBuilder.Entity<ModelAttribute>().HasData(defaultModel.ModelAttributes);

            modelBuilder.Entity<ModelAttributeScope>().HasData(defaultModel.ModelAttributeScopes);

            modelBuilder.Entity<ModelAttributeMember>().HasData(defaultModel.ModelAttributeMembers);

            modelBuilder.Entity<SecurityTypeGroup>().HasData(defaultModel.SecurityTypeGroups);

            modelBuilder.Entity<SecurityTypeGroup>().HasData(defaultModel.SecurityTypes);

            modelBuilder.Entity<SecuritySymbolType>().HasData(defaultModel.SecuritySymbolTypes);

            #endregion
        }
    }
}
