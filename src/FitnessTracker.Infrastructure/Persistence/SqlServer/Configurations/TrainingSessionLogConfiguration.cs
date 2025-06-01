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
    public class TrainingSessionLogConfiguration : IEntityTypeConfiguration<TrainingSessionLog>
    {
        public void Configure(EntityTypeBuilder<TrainingSessionLog> builder)
        {
            builder.ToTable("training_session_log");
            builder.HasKey(sessionLog => sessionLog.Id);
            builder.Property(sessionLog => sessionLog.Id).HasColumnName("training_session_log_id").IsRequired();

            builder.Property(sessionLog => sessionLog.RepsCompleted).HasColumnName("reps_completed");
            builder.Property(sessionLog => sessionLog.SetsCompleted).HasColumnName("sets_completed");
            builder.Property(sessionLog => sessionLog.LiftedWeight).HasColumnName("lifted_weight").HasPrecision(5, 1);
            builder.Property(sessionLog => sessionLog.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(sessionLog => sessionLog.CreatedByAccountId).HasColumnName("created_by_account_id").IsRequired();
            builder.Property(sessionLog => sessionLog.TrainingSessionId).HasColumnName("training_session_id").IsRequired();
            builder.Property(sessionLog => sessionLog.TrainingExerciseId).HasColumnName("training_exercise_id").IsRequired();

            builder.HasOne(sessionLog => sessionLog.TrainingSession)
                .WithMany(session => session.TrainingSessionLogs)
                .HasForeignKey(sessionLog => sessionLog.TrainingSessionId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(sessionLog => sessionLog.TrainingExercise)
                .WithMany(exercise => exercise.TrainingSessionLogs)
                .HasForeignKey(sessionLog => sessionLog.TrainingExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sessionLog => sessionLog.CreatedByAccount)
                .WithMany(account => account.CreatedTrainingSessionLogs)
                .HasForeignKey(sessionLog => sessionLog.CreatedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
