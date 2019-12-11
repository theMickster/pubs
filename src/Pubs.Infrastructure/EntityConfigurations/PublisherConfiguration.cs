using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.Core.Entities;

namespace Pubs.Infrastructure.EntityConfigurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("publishers", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("publisher_id");

            builder.Property(a => a.PublisherCode).HasColumnName("publisher_code");

            builder.Property(a => a.PublisherName).HasColumnName("publisher_name");

            builder.Property(a => a.ZipCode).HasColumnName("zip_code");

        }
    }
}