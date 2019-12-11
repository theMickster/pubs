using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class PublisherLogoConfiguration : BaseConfiguration, IEntityTypeConfiguration<PublisherLogo>
    {
        public PublisherLogoConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<PublisherLogo> builder)
        {
            builder.ToTable("publisher_info", _schema);

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