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
    public class TrainingExerciseConfiguration : IEntityTypeConfiguration<TrainingExercise>
    {
        public void Configure(EntityTypeBuilder<TrainingExercise> builder)
        {
            builder.ToTable("training_exercise");
            builder.HasKey(exercise=> exercise.Id);
            builder.Property(exercise=> exercise.Id).HasColumnName("training_exercise_id").IsRequired();

            builder.Property(exercise=> exercise.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
            builder.Property(exercise=> exercise.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(exercise=> exercise.Publicity).HasColumnName("publicity").IsRequired();
            builder.Property(exercise=> exercise.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(exercise=> exercise.CreatedByAccountId).HasColumnName("created_by_account_id").IsRequired();

            builder.HasOne(exercise=> exercise.CreatedByAccount)
                   .WithMany(account => account.CreatedTrainingExercises)
                   .HasForeignKey(exercise=> exercise.CreatedByAccountId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(exercise=> exercise.ExerciseSpecializations)
                   .WithOne(es => es.TrainingExercise)
                   .HasForeignKey(es => es.TrainingExerciseId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(exercise=> exercise.TrainingSessionGoals)
                   .WithOne(tsg => tsg.TrainingExercise)
                   .HasForeignKey(tsg => tsg.TrainingExerciseId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(exercise=> exercise.TrainingSessionLogs)
                   .WithOne(tsl => tsl.TrainingExercise)
                   .HasForeignKey(tsl => tsl.TrainingExerciseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
