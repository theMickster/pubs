using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class TitleConfiguration : BaseConfiguration, IEntityTypeConfiguration<Title>
    {
        public TitleConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("titles", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("title_id");

            builder.Property(a => a.TitleCode).HasColumnName("title_code");

            builder.Property(a => a.TitleName).HasColumnName("title");

            builder.Property(a => a.TitleType).HasColumnName("title_type");

            builder.Property(a => a.PublisherId).HasColumnName("publisher_id");

            builder.Property(a => a.PublisherCode).HasColumnName("publisher_code");

            builder.Property(a => a.YearToDateSales).HasColumnName("year_to_date_sales");
            
            builder.Property(a => a.PublishedDate).HasColumnName("published_date");

            builder.Property(a => a.Price).HasColumnType("Money");

            builder.Property(a => a.Advance).HasColumnType("Money");

            builder.HasOne(a => a.Publisher)
                .WithMany(b => b.Titles)
                .HasForeignKey(a => a.PublisherId);
        }
    }
}