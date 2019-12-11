using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.Core.Entities;

namespace Pubs.Infrastructure.EntityConfigurations
{
    public class PublisherLogoConfiguration : IEntityTypeConfiguration<PublisherLogo>
    {
        public void Configure(EntityTypeBuilder<PublisherLogo> builder)
        {
            builder.ToTable("publisher_info", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("publisher_id");

            builder.Property(a => a.PublisherCode).HasColumnName("publisher_code");

            builder.Property(a => a.Logo).HasColumnName("logo");

            builder.Property(a => a.PublisherInfo).HasColumnName("publisher_info");

            builder.HasOne(a => a.Publisher)
                .WithMany(b => b.PublisherLogos)
                .HasForeignKey(a => a.Id);

        }
    }
}