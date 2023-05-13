using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NjordinSight.EntityModel.Context.Configurations
{
    public class SecurityExchangeConfiguration : IEntityTypeConfiguration<SecurityExchange>
    {
        public void Configure(EntityTypeBuilder<SecurityExchange> builder)
        {
            builder.HasData(
                new SecurityExchange() { ExchangeId = -1, ExchangeCode = "TSX", ExchangeDescription = "TSX" },
                new SecurityExchange() { ExchangeId = -2, ExchangeCode = "NYSE", ExchangeDescription = "NYSE" },
                new SecurityExchange() { ExchangeId = -3, ExchangeCode = "OTCQX", ExchangeDescription = "OTCQX" },
                new SecurityExchange() { ExchangeId = -4, ExchangeCode = "NYSE American", ExchangeDescription = "NYSE American" },
                new SecurityExchange() { ExchangeId = -5, ExchangeCode = "NASDAQ", ExchangeDescription = "NASDAQ" },
                new SecurityExchange() { ExchangeId = -6, ExchangeCode = "OTCQB", ExchangeDescription = "OTCQB" },
                new SecurityExchange() { ExchangeId = -7, ExchangeCode = "OTC Pink", ExchangeDescription = "OTC Pink" },
                new SecurityExchange() { ExchangeId = -8, ExchangeCode = "NYSE Arca", ExchangeDescription = "NYSE Arca" },
                new SecurityExchange() { ExchangeId = -9, ExchangeCode = "CBOE Consolidated Listings", ExchangeDescription = "CBOE Consolidated Listings" }
                );
        }
    }
}
