using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class PublisherConfiguration : BaseConfiguration, IEntityTypeConfiguration<Publisher>
    {
        public PublisherConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("publishers", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("publisher_id");

            builder.Property(a => a.PublisherCode).HasColumnName("publisher_code");

            builder.Property(a => a.PublisherName).HasColumnName("publisher_name");

            builder.Property(a => a.ZipCode).HasColumnName("zip_code");

        }
    }
}