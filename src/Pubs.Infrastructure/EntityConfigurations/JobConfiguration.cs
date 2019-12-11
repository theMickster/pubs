using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.Core.Entities;

namespace Pubs.Infrastructure.EntityConfigurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("jobs", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("job_id");

            builder.Property(a => a.JobDescription).HasColumnName("job_desc");

            builder.Property(a => a.MinimumLevel).HasColumnName("min_lvl");

            builder.Property(a => a.MaximumLevel).HasColumnName("max_lvl");

        }
    }
}