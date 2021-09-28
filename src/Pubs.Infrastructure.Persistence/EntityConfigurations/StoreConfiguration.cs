using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class StoreConfiguration : BaseConfiguration, IEntityTypeConfiguration<Store>
    {
        public StoreConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("stores", _schema);

            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.Id).HasColumnName("store_id");

            builder.Property(a => a.StoreCode).HasColumnName("store_code");

            builder.Property(a => a.StoreName).HasColumnName("store_name");

            builder.Property(a => a.StoreAddress).HasColumnName("store_address");

            builder.Property(a => a.ZipCode).HasColumnName("zip_code");
        }
    }
}