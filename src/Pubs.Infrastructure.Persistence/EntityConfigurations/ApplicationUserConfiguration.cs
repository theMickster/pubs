using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : BaseConfiguration, IEntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("application_users", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("application_user_id");

            builder.Property(a => a.ApplicationUserStatusId).HasColumnName("application_user_status_id");

            builder.Property(a => a.UserName).HasColumnName("username");

            builder.Property(a => a.UserPrincipalName).HasColumnName("user_principal_name");

            builder.Property(a => a.FirstName).HasColumnName("first_name");

            builder.Property(a => a.MiddleName).HasColumnName("middle_name");

            builder.Property(a => a.LastName).HasColumnName("last_name");

            builder.Property(a => a.EmailAddress).HasColumnName("email_address");

            builder.Property(a => a.PhoneNumber).HasColumnName("phone_number");

            builder.Property(a => a.LastSuccessfulLogin).HasColumnName("last_successful_login");

            builder.HasOne(a => a.ApplicationUserStatus)
                .WithMany(b => b.ApplicationUsers)
                .HasForeignKey(c => c.ApplicationUserStatusId);
        }
    }
}
