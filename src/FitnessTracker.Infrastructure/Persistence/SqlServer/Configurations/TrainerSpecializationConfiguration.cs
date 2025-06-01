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
    public class TrainerSpecializationConfiguration : IEntityTypeConfiguration<TrainerSpecialization>
    {
        public void Configure(EntityTypeBuilder<TrainerSpecialization> builder)
        {
            builder.ToTable("trainer_specialization");
            builder.HasKey(trainerSpecialization => trainerSpecialization.Id);
            builder.Property(trainerSpecialization => trainerSpecialization.Id).HasColumnName("trainer_specialization_id").IsRequired();

            builder.Property(trainerSpecialization => trainerSpecialization.TrainerAccountId).HasColumnName("trainer_account_id").IsRequired();
            builder.Property(trainerSpecialization => trainerSpecialization.TrainingSpecializationId).HasColumnName("training_specialization_id").IsRequired();

            builder.HasOne(trainerSpecialization => trainerSpecialization.TrainerAccount)
                   .WithMany(account => account.TrainerSpecializations)
                   .HasForeignKey(trainerSpecialization => trainerSpecialization.TrainerAccountId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(trainerSpecialization => trainerSpecialization.TrainingSpecialization)
                   .WithMany(trainingSpecialization => trainingSpecialization.TrainerSpecializations)
                   .HasForeignKey(trainerSpecialization => trainerSpecialization.TrainingSpecializationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
