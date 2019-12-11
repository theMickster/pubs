using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class DiscountConfiguration : BaseConfiguration, IEntityTypeConfiguration<Discount>
    {
        public DiscountConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("discounts", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("discount_id");

            builder.Property(a => a.DiscountType).HasColumnName("discount_type");

            builder.Property(a => a.StoreId).HasColumnName("store_id");

            builder.Property(a => a.StoreCode).HasColumnName("store_code");

            builder.Property(a => a.LowQuantity).HasColumnName("low_qty");
            
            builder.Property(a => a.HighQuantity).HasColumnName("high_qty");

            builder.Property(a => a.DiscountAmount).HasColumnName("discount");

            builder.HasOne(a => a.Store)
                .WithMany(b => b.Discounts)
                .HasForeignKey(a => a.StoreId);
        }
    }
}