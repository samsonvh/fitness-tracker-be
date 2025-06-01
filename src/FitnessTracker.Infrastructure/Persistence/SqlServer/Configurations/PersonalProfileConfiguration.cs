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
    public class PersonalProfileConfiguration : IEntityTypeConfiguration<PersonalProfile>
    {
        public void Configure(EntityTypeBuilder<PersonalProfile> builder)
        {
            builder.ToTable("personal_profile");
            builder.HasKey(profile => profile.Id);
            builder.Property(profile => profile.Id).HasColumnName("personal_profile_id").IsRequired();

            builder.Property(profile => profile.FirstName).HasColumnName("first_name").IsRequired().HasMaxLength(50);
            builder.Property(profile => profile.LastName).HasColumnName("last_name").IsRequired().HasMaxLength(50);
            builder.Property(profile => profile.DateOfBirth).HasColumnName("date_of_birth").IsRequired();
            builder.Property(profile => profile.AccountId).HasColumnName("account_id").IsRequired();

            builder.HasOne(profile => profile.Account)
                   .WithOne(account => account.PersonalProfile)
                   .HasForeignKey<PersonalProfile>(profile => profile.AccountId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
