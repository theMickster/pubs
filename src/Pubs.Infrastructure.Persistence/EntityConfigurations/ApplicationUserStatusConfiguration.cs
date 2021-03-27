using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class ApplicationUserStatusConfiguration : BaseConfiguration, IEntityTypeConfiguration<ApplicationUserStatus>
    {
        public ApplicationUserStatusConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<ApplicationUserStatus> builder)
        {
            builder.ToTable("application_user_statuses", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("application_user_status_id");

            builder.Property(a => a.StatusAbbreviation).HasColumnName("status_abbreviation");

            builder.Property(a => a.StatusName).HasColumnName("status_name");

        }
    }
}
