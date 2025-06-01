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
    public class TrainingSessionConfiguration : IEntityTypeConfiguration<TrainingSession>
    {
        public void Configure(EntityTypeBuilder<TrainingSession> builder)
        {
            builder.ToTable("training_session");
            builder.HasKey(session => session.Id);
            builder.Property(session => session.Id).HasColumnName("training_session_id").IsRequired();

            builder.Property(session => session.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
            builder.Property(session => session.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(session => session.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(session => session.EndDate).HasColumnName("end_date").IsRequired();
            builder.Property(session => session.TrainingPlanId).HasColumnName("training_plan_id").IsRequired();

            builder.HasOne(session => session.TrainingPlan)
                   .WithMany(plan => plan.TrainingSessions)
                   .HasForeignKey(session => session.TrainingPlanId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
