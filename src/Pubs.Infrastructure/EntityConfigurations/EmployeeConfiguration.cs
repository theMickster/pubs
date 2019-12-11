using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.Core.Entities;

namespace Pubs.Infrastructure.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("employee_id");

            builder.Property(a => a.EmployeeCode).HasColumnName("employee_code");

            builder.Property(a => a.FirstName).HasColumnName("first_name");

            builder.Property(a => a.MiddleName).HasColumnName("middle_name");

            builder.Property(a => a.LastName).HasColumnName("last_name");

            builder.Property(a => a.JobId).HasColumnName("job_id");

            builder.Property(a => a.JobLevel).HasColumnName("job_lvl");

            builder.Property(a => a.PublisherId).HasColumnName("publisher_id");

            builder.Property(a => a.PublisherCode).HasColumnName("publisher_code");

            builder.Property(a => a.HireDate).HasColumnName("hire_date");

            builder.HasOne(a => a.Job)
                .WithMany(b => b.Employees)
                .HasForeignKey(a => a.JobId);
            
            builder.HasOne(a => a.Publisher)
                .WithMany(b => b.Employees)
                .HasForeignKey(a => a.PublisherId);
        }
    }
}