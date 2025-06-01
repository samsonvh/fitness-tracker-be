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
    public class PartnershipConfiguration : IEntityTypeConfiguration<Partnership>
    {
        public void Configure(EntityTypeBuilder<Partnership> builder)
        {
            builder.ToTable("partnership");
            builder.HasKey(partnership => partnership.Id);
            builder.Property(partnership => partnership.Id).HasColumnName("partnership_id").IsRequired();

            builder.Property(partnership => partnership.Status).HasColumnName("status").IsRequired();
            builder.Property(partnership => partnership.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(partnership => partnership.TrainerAccountId).HasColumnName("trainer_account_id").IsRequired();
            builder.Property(partnership => partnership.ClientAccountId).HasColumnName("client_account_id").IsRequired();
            
            builder.HasOne(partnership => partnership.TrainerAccount)
                .WithMany(account => account.PartnershipsAsTrainer)
                .HasForeignKey(partnership => partnership.TrainerAccountId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.HasOne(partnership => partnership.ClientAccount)
                .WithMany(account => account.PartnershipsAsClient)
                .HasForeignKey(partnership => partnership.ClientAccountId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
