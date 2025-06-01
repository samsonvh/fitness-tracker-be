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
    public class TrainingPlanGoalConfiguration : IEntityTypeConfiguration<TrainingPlanGoal>
    {
        public void Configure(EntityTypeBuilder<TrainingPlanGoal> builder)
        {
            builder.ToTable("training_plan_goal");
            builder.HasKey(goal => goal.Id);
            builder.Property(goal => goal.Id).HasColumnName("training_plan_goal_id").IsRequired();

            builder.Property(goal => goal.Description).HasColumnName("description").IsRequired();
            builder.Property(goal => goal.TargetWeight).HasColumnName("target_weight").HasPrecision(5, 1);
            builder.Property(goal => goal.Status).HasColumnName("status").IsRequired();
            builder.Property(goal => goal.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(goal => goal.TrainingPlanId).HasColumnName("training_plan_id").IsRequired();

            builder.HasOne(goal => goal.TrainingPlan)
                .WithMany(plan => plan.TrainingPlanGoals)
                .HasForeignKey(goal => goal.TrainingPlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
