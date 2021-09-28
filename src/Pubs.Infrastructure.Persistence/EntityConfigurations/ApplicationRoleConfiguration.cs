using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class ApplicationRoleConfiguration : BaseConfiguration, IEntityTypeConfiguration<ApplicationRole>
    {
        public ApplicationRoleConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("application_roles", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("application_role_id");

            builder.Property(a => a.RoleName).HasColumnName("role_name");

        }
    }
}
