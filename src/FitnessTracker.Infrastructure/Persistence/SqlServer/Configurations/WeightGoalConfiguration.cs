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
    public class WeightGoalConfiguration : IEntityTypeConfiguration<WeightGoal>
    {
        public void Configure(EntityTypeBuilder<WeightGoal> builder)
        {
            builder.ToTable("weight_goal");
            builder.HasKey(goal => goal.Id);
            builder.Property(goal => goal.Id).HasColumnName("weight_goal_id").IsRequired();

            builder.Property(goal => goal.TargetWeight).HasColumnName("target_weight").HasPrecision(5, 1).IsRequired();
            builder.Property(goal => goal.Unit).HasColumnName("unit").IsRequired().HasMaxLength(10);
            builder.Property(goal => goal.TargetDate).HasColumnName("target_date").IsRequired();
            builder.Property(goal => goal.Status).HasColumnName("status").IsRequired();
            builder.Property(goal => goal.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(goal => goal.CreatedByAccountId).HasColumnName("created_by_account_id").IsRequired();

            builder.HasOne(goal => goal.CreatedByAccount)
                .WithMany(account => account.WeightGoals)
                .HasForeignKey(goal => goal.CreatedByAccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
