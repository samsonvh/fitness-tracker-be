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
    public class TrainingPlanConfiguration : IEntityTypeConfiguration<TrainingPlan>
    {
        public void Configure(EntityTypeBuilder<TrainingPlan> builder)
        {
            builder.ToTable("training_plan");
            builder.HasKey(trainingPlan => trainingPlan.Id);
            builder.Property(trainingPlan => trainingPlan.Id).HasColumnName("training_plan_id").IsRequired();

            builder.Property(trainingPlan => trainingPlan.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
            builder.Property(trainingPlan => trainingPlan.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(trainingPlan => trainingPlan.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(trainingPlan => trainingPlan.EndDate).HasColumnName("end_date").IsRequired();
            builder.Property(trainingPlan => trainingPlan.IsPersonalPlan).HasColumnName("is_personal_plan").IsRequired();
            builder.Property(trainingPlan => trainingPlan.Status).HasColumnName("status").IsRequired();
            builder.Property(trainingPlan => trainingPlan.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(trainingPlan => trainingPlan.ClientAccountId).HasColumnName("client_account_id");
            builder.Property(trainingPlan => trainingPlan.CreatedByAccountId).HasColumnName("created_by_account_id").IsRequired();

            builder.HasOne(trainingPlan => trainingPlan.ClientAccount)
                .WithMany(account => account.AssignedTrainingPlans)
                .HasForeignKey(trainingPlan => trainingPlan.ClientAccountId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(trainingPlan => trainingPlan.CreatedByAccount)
                .WithMany(account => account.CreatedTrainingPlans)
                .HasForeignKey(trainingPlan => trainingPlan.CreatedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
