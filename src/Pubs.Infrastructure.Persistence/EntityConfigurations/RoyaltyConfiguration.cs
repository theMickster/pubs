using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class RoyaltyConfiguration : BaseConfiguration, IEntityTypeConfiguration<Royalty>
    {
        public RoyaltyConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Royalty> builder)
        {
            builder.ToTable("royalty", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("royalty_id");

            builder.Property(a => a.TitleId).HasColumnName("title_id");

            builder.Property(a => a.TitleCode).HasColumnName("title_code");

            builder.Property(a => a.LowRange).HasColumnName("lorange");
            
            builder.Property(a => a.HighRange).HasColumnName("hirange");

            builder.Property(a => a.RoyaltyAmount).HasColumnName("royalty");

            builder.HasOne(a => a.Title)
                .WithMany(b => b.Royalties)
                .HasForeignKey(a => a.TitleId);

        }
    }
}