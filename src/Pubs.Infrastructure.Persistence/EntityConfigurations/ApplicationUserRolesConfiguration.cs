using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class ApplicationUserRoleConfiguration : BaseConfiguration, IEntityTypeConfiguration<ApplicationUserRole>
    {
        public ApplicationUserRoleConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("application_user_roles", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("application_user_role_id");

            builder.Property(a => a.ApplicationUserId).HasColumnName("application_user_id");

            builder.Property(a => a.ApplicationRoleId).HasColumnName("application_role_id");

            builder.HasOne(a => a.ApplicationUser)
                .WithMany(b => b.ApplicationUserRoles)
                .HasForeignKey(c => c.ApplicationUserId);

            builder.HasOne(a => a.ApplicationRole)
                .WithMany(b => b.ApplicationUserRoles)
                .HasForeignKey(c => c.ApplicationRoleId);
        }
    }
}
