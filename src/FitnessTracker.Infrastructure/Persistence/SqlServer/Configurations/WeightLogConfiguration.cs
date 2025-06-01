using FitnessTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Persistence.SqlServer.Configurations
{
    public class WeightLogConfiguration : IEntityTypeConfiguration<WeightLog>
    {
        public void Configure(EntityTypeBuilder<WeightLog> builder)
        {
            builder.ToTable("weight_log");
            builder.HasKey(weightLog => weightLog.Id);
            builder.Property(weightLog => weightLog.Id).HasColumnName("weight_log_id").IsRequired();

            builder.Property(weightLog => weightLog.Weight).HasColumnName("weight").IsRequired().HasPrecision(5, 1);
            builder.Property(weightLog => weightLog.Unit).HasColumnName("unit").IsRequired().HasMaxLength(10);
            builder.Property(weightLog => weightLog.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(weightLog => weightLog.CreatedByAccountId).HasColumnName("created_by_account_id").IsRequired();

            builder.HasOne(weightLog => weightLog.CreatedByAccount)
                   .WithMany(account => account.CreatedWeightLogs)
                   .HasForeignKey(weightLog => weightLog.CreatedByAccountId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
