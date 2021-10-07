using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class AuthorTitleConfiguration : BaseConfiguration, IEntityTypeConfiguration<AuthorTitle>
    {
        public AuthorTitleConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<AuthorTitle> builder)
        {
            builder.ToTable("titles_xref_authors", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("title_xref_author_id");

            builder.Property(a => a.TitleId).HasColumnName("title_id");

            builder.Property(a => a.TitleCode).HasColumnName("title_code");

            builder.Property(a => a.AuthorId).HasColumnName("author_id");

            builder.Property(a => a.AuthorCode).HasColumnName("author_code");

            builder.Property(a => a.AuthorOrder).HasColumnName("author_order").HasColumnType("tinyint");

            builder.Property(a => a.Royalty).HasColumnName("royaltyper");

            builder.HasOne(a => a.Author).WithMany(b => b.AuthorTitles).HasForeignKey(c => c.AuthorId);

            builder.HasOne(a => a.Title).WithMany(b => b.AuthorTitles).HasForeignKey(c => c.TitleId);
        }
    }
}
