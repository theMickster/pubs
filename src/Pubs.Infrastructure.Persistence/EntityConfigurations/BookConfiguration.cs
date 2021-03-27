using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class BookConfiguration : BaseConfiguration, IEntityTypeConfiguration<Book>
    {
        public BookConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Book> builder)
        {
        }
    }
}