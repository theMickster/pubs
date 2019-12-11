using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.Core.Entities;

namespace Pubs.Infrastructure.EntityConfigurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("sales", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("sale_id");

            builder.Property(a => a.StoreId).HasColumnName("store_id");

            builder.Property(a => a.StoreCode).HasColumnName("store_code");

            builder.Property(a => a.OrderNumber).HasColumnName("ord_num");
            
            builder.Property(a => a.OrderDate).HasColumnName("ord_date");

            builder.Property(a => a.Quantity).HasColumnName("qty");

            builder.Property(a => a.PaymentTerms).HasColumnName("payterms");

            builder.Property(a => a.TitleId).HasColumnName("title_id");

            builder.Property(a => a.TitleCode).HasColumnName("title_code");

            builder.HasOne(a => a.Title)
                .WithMany(b => b.Sales)
                .HasForeignKey(a => a.TitleId);
            
            builder.HasOne(a => a.Store)
                .WithMany(b => b.Sales)
                .HasForeignKey(a => a.StoreId);
        }
    }
}