using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.Persistence.EntityConfigurations
{
    public class JobConfiguration : BaseConfiguration, IEntityTypeConfiguration<Job>
    {
        public JobConfiguration(string schema) : base(schema)
        {
        }

        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("jobs", _schema);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("job_id");

            builder.Property(a => a.JobDescription).HasColumnName("job_desc");

            builder.Property(a => a.MinimumLevel).HasColumnName("min_lvl");

            builder.Property(a => a.MaximumLevel).HasColumnName("max_lvl");

        }
    }
}