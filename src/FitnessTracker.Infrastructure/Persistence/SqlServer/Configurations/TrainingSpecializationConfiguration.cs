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
    public class TrainingSpecializationConfiguration : IEntityTypeConfiguration<TrainingSpecialization>
    {
        public void Configure(EntityTypeBuilder<TrainingSpecialization> builder)
        {
            builder.ToTable("training_specialization");
            builder.HasKey(trainingSpecialization => trainingSpecialization.Id);
            builder.Property(trainingSpecialization => trainingSpecialization.Id).HasColumnName("training_specialization_id").IsRequired();

            builder.Property(trainingSpecialization => trainingSpecialization.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
        }
    }
}
