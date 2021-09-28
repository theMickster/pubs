using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class AuthorConfiguration : BaseConfiguration, IEntityTypeConfiguration<Author>
    {
        public AuthorConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("author_id");

            builder.Property(a => a.AuthorCode).HasColumnName("author_code");

            builder.Property(a => a.LastName).HasColumnName("last_name");
            
            builder.Property(a => a.FirstName).HasColumnName("first_name");

            builder.Property(a => a.PhoneNumber).HasColumnName("phone_number");

            builder.Property(a => a.ZipCode).HasColumnName("zip_code");

        }
    }
}