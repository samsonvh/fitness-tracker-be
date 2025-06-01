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
    public class TrainingSessionGoalConfiguration : IEntityTypeConfiguration<TrainingSessionGoal>
    {
        public void Configure(EntityTypeBuilder<TrainingSessionGoal> builder)
        {
            builder.ToTable("training_session_goal");
            builder.HasKey(goal => goal.Id);
            builder.Property(goal => goal.Id).HasColumnName("training_session_goal_id").IsRequired();

            builder.Property(goal => goal.Description).HasColumnName("description");
            builder.Property(goal => goal.TargetReps).HasColumnName("target_reps");
            builder.Property(goal => goal.TargetSets).HasColumnName("target_sets");
            builder.Property(goal => goal.TargetLiftingWeight).HasPrecision(5, 1).HasColumnName("target_lifting_weight");
            builder.Property(goal => goal.Status).HasColumnName("status").IsRequired();
            builder.Property(goal => goal.TrainingSessionId).HasColumnName("training_session_id").IsRequired();
            builder.Property(goal => goal.TrainingExerciseId).HasColumnName("training_exercise_id").IsRequired();

            builder.HasOne(goal => goal.TrainingExercise)
                   .WithMany(exercise => exercise.TrainingSessionGoals)
                   .HasForeignKey(goal => goal.TrainingExerciseId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(goal => goal.TrainingSession)
                     .WithMany(session => session.TrainingSessionGoals)
                     .HasForeignKey(goal => goal.TrainingSessionId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
