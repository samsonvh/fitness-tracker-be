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
    public class ExerciseSpecializationConfiguration : IEntityTypeConfiguration<ExerciseSpecialization>
    {
        public void Configure(EntityTypeBuilder<ExerciseSpecialization> builder)
        {
            builder.ToTable("exercise_specialization");
            builder.HasKey(exerciseSpecialization => exerciseSpecialization.Id);
            builder.Property(exerciseSpecialization => exerciseSpecialization.Id).HasColumnName("exercise_specialization_id").IsRequired();

            builder.Property(exerciseSpecialization => exerciseSpecialization.TrainingSpecializationId).HasColumnName("training_specialization_id").IsRequired();
            builder.Property(exerciseSpecialization => exerciseSpecialization.TrainingExerciseId).HasColumnName("training_exercise_id").IsRequired();

            builder.HasOne(exerciseSpecialization => exerciseSpecialization.TrainingSpecialization)
                .WithMany(specialization => specialization.ExerciseSpecializations)
                .HasForeignKey(exerciseSpecialization => exerciseSpecialization.TrainingSpecializationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(exerciseSpecialization => exerciseSpecialization.TrainingExercise)
                .WithMany(exercise => exercise.ExerciseSpecializations)
                .HasForeignKey(exerciseSpecialization => exerciseSpecialization.TrainingExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
